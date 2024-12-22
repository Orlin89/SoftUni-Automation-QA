using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace WorkshopAdvanced
{
    [TestFixture]
    public class CouponManagementTests
    {
        private RestClient client;
        private string adminToken;
        private string userToken;
        private Random random;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            adminToken = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");
            userToken = GlobalConstants.AuthenticateUser("john.doe@example.com", "password123");
            random = new Random();
        }

        [TearDown]
        public void Dispose()
        {
            client.Dispose();
        }

        [Test]
        public void CouponLifecycleTest()
        {
            //Get products from the system
            var getProductsRequest = new RestRequest("/product", Method.Get);
            getProductsRequest.AddHeader("Authorization", $"Bearer {adminToken}");

            var getProductsResponse = client.Execute(getProductsRequest);
            Assert.That(getProductsResponse.IsSuccessful, Is.True, "Fetching products failed");

            var products = JArray.Parse(getProductsResponse.Content);
            Assert.That(products.Count, Is.GreaterThanOrEqualTo(2), 
                "Not enough products available for the test");

            //Get two random products from the array by random array index
            
            var productIds = products.Select(p => p["_id"]?.ToString()).ToList();
            string firstProductId = productIds[random.Next(productIds.Count)];
            string secondProductId = productIds[random.Next(productIds.Count)];

            //if we hava same products we somehow need to make them different
            while (firstProductId == secondProductId)
            {
                secondProductId = productIds[random.Next(productIds.Count)];
            }

            //Create ne random coupon
            string couponName = "DISCOUNT20-" + random.Next(999, 9999).ToString();
            var createCouponRequest = new RestRequest("/coupon", Method.Post);
            createCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createCouponRequest.AddJsonBody(new
            {
                Name = couponName,
                Discount = 20,
                Expiry = "2024-12-31"
            });

            var createCouponResponse = client.Execute(createCouponRequest);
            Assert.That(createCouponResponse.IsSuccessful, Is.True, "Coupon creation failed");

            string couponId = JObject.Parse(createCouponResponse.Content)["_id"]?.ToString();
            Assert.That(couponId, Is.Not.Null.Or.Empty, "Coupon ID should not be null or empty");

            //Create shopping cart and adds the two random products inside
            var createCartRequest = new RestRequest("/user/cart", Method.Post);
            createCartRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createCartRequest.AddJsonBody(new
            {
                cart = new[]
                {
                    new { _id = firstProductId, count = 1, color = "red" },
                    new { _id = secondProductId, count = 2, color = "blue" }
                }
            });

            var createCartResponse = client.Execute(createCartRequest);
            Assert.That(createCartResponse.IsSuccessful, Is.True, "Cart creation failed");

            //Apply the coupon to the user cart
            var applyCouponRequest = new RestRequest("/user/cart/applycoupon", Method.Post);
            applyCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            applyCouponRequest.AddJsonBody(new
            {
                Coupon = couponName
            });

            var applyCouponResponse = client.Execute(applyCouponRequest);

            Assert.That(applyCouponResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Expected status code OK (200)");

            //Delete the coupon and assert
            var deleteCouponRequest = new RestRequest($"/coupon/{couponId}", Method.Delete);
            deleteCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            var deleteCouponResponse = client.Execute(deleteCouponRequest);
            Assert.That(deleteCouponResponse.IsSuccessful, Is.True, "Coupon deletion failed");

            //Get coupons and assert its deleted
            var verifyCouponRequest = new RestRequest($"/coupon/{couponId}", Method.Get);
            verifyCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            var verifyCouponResponse = client.Execute(verifyCouponRequest);
            Assert.That(verifyCouponResponse.Content, Is.Null.Or.EqualTo("null"), 
                "Coupon still exists after deletion");
        }

        [Test]
        public void CouponApplicationToOrderTest()
        {
            //Get all products and pick a product with its id
            var getProductsRequest = new RestRequest("/product", Method.Get);  
            getProductsRequest.AddHeader("Authorization", $"Bearer {adminToken}");

            var getProductsResponse = client.Execute(getProductsRequest);
            Assert.That(getProductsResponse.IsSuccessful, Is.True, "Fetching products failed");

            var products = JArray.Parse(getProductsResponse.Content);
            Assert.That(products.Count, Is.GreaterThan(0), "No products available for the test");

            string productId = products.First()["_id"]?.ToString();
            Assert.That(productId, Is.Not.Null.Or.Empty, "Product ID should not be null or empty");

            //Create a new coupon
            string couponName = "SAVE10-" + random.Next(999, 9999).ToString();
            var createCouponRequest = new RestRequest("/coupon", Method.Post);
            createCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createCouponRequest.AddJsonBody(new
            {
                Name = couponName,
                Discount = 10,
                Expiry = "2026-12-31"
            });

            var createCouponResponse = client.Execute(createCouponRequest);
            Assert.That(createCouponResponse.IsSuccessful, Is.True, "Coupon creation failed");

            //Add the product to the user cart
            var addToCartRequest = new RestRequest("/user/cart", Method.Post);
            addToCartRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToCartRequest.AddJsonBody(new
            {
                cart = new[]
                {
                    new { _id = productId, count = 2, color = "Red" }
                }
            });

            var addToCartResponse = client.Execute(addToCartRequest);
            Assert.That(addToCartResponse.IsSuccessful, Is.True, "Adding product to cart failed");

            //Apply the coupon to the cart.
            var applyCouponRequest = new RestRequest("/user/cart/applycoupon", Method.Post);
            applyCouponRequest.AddHeader("Authorization", $"Bearer {userToken}");
            applyCouponRequest.AddJsonBody(new
            {
                coupon = couponName
            });

            var applyCouponResponse = client.Execute(applyCouponRequest);
            Assert.That(applyCouponResponse.IsSuccessful, Is.True, "Applying coupon to cart failed");
            
            //Place the order with the applied coupon
            var placeOrderRequest = new RestRequest("/user/cart/cash-order", Method.Post);
            placeOrderRequest.AddHeader("Authorization", $"Bearer {userToken}");
            placeOrderRequest.AddJsonBody(JsonConvert.SerializeObject(new
            {
                COD = true,
                couponApplied = false
            }));

            var placeOrderResponse = client.Execute(placeOrderRequest);
            Assert.That(placeOrderResponse.IsSuccessful, Is.True, "Placing order failed");
        }
    }
}
