using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTestingBasics
{
    [TestFixture]
    public class ProductApiTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void Setup() 
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token is null or empty");
        }

        public void Dispose()
        {
            client?.Dispose();
        }

        [Test, Order(1)]
        public void Test_GetAllProducts()
        {
            //Arrange
            var request = new RestRequest("product", Method.Get);

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not OK");
                Assert.That(response.Content, Is.Not.Empty, "Response content is empty");

                var content = JArray.Parse(response.Content);

                var productTitle = new[]
                {
                    "Smartphone Alpha", "Wireless Headphones", "Gaming Laptop", "4K Ultra HD TV", "Smartwatch Pro"
                };

                foreach (var title in productTitle)
                {
                    Assert.That(content.ToString(), Does.Contain(title));
                }

                var expectedPrices = new Dictionary<string, decimal> {
                    { "Smartphone Alpha", 999},
                    { "Wireless Headphones", 199},
                    { "Gaming Laptop", 1499},
                    { "4K Ultra HD TV", 899},
                    { "Smartwatch Pro", 299}
                };

                foreach(var product in content) 
                {
                    var title = product["title"].ToString();

                    if (expectedPrices.ContainsKey(title)) {
                        Assert.That(product["price"].Value<decimal>(), Is.EqualTo(expectedPrices[title]));
                    }
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddProduct()
        {
            //Arrange
            var request = new RestRequest("product", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "New Test Product",
                slug = "new-test-product",
                description = "New Description",
                price = 99.99,
                category = "test",
                brand = "test",
                quantity = 50
            });

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JObject.Parse(response.Content);

                Assert.That(content["title"].ToString(), Is.EqualTo("New Test Product"));
                Assert.That(content["slug"].ToString(), Is.EqualTo("new-test-product"));
                Assert.That(content["description"].ToString(), Is.EqualTo("New Description"));
                Assert.That(content["price"].Value<decimal>(), Is.EqualTo(99.99));
                Assert.That(content["category"].ToString(), Is.EqualTo("test"));
                Assert.That(content["brand"].ToString(), Is.EqualTo("test"));
                Assert.That(content["quantity"].Value<int>(), Is.EqualTo(50));
            });
        }

        [Test, Order(3)]
        public void Test_UpdateProduct_InvalidProductId()
        {
            //Arrange
            var invalidId = "InvalidID";
            var udpateRequest = new RestRequest("product/{id}", Method.Put);
            udpateRequest.AddUrlSegment("id", invalidId);
            udpateRequest.AddHeader("Authorization", $"Bearer {token}");
            udpateRequest.AddJsonBody(new
            {
                title = "Updated New Test Product2",
                slug = "udpated-new-test-product2",
                description = "Udpaetd New Description",
                price = 99.99,
                category = "test",
                brand = "test",
                quantity = 50
            });

            //Act
            var updatedResponse = client.Execute(udpateRequest);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(updatedResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError).Or.EqualTo(HttpStatusCode.BadRequest));

                Assert.That(updatedResponse.Content, Does.Contain("This id is not valid or not Found").Or.Contain("Invalid Id"));
            });
        }

        [Test, Order(4)]
        public void Test_DeleteProduct() {
            //Arrange
            var getRequest = new RestRequest("product", Method.Get);
            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not OK");
            Assert.That(getResponse.Content, Is.Not.Empty, "Response content is empty");

            var products = JArray.Parse(getResponse.Content);
            var productToDelete = products.FirstOrDefault(p => p["slug"]?.ToString() == "new-test-product");

            Assert.That(productToDelete, Is.Not.Null);

            var productId = productToDelete["_id"]?.ToString();

            var deleteRequest = new RestRequest("product/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", productId);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var verifyGetRequest = new RestRequest("product/{id}", Method.Get);
            verifyGetRequest.AddUrlSegment("id", productId);

            var verifyResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyResponse.Content, Is.EqualTo("null"));
        }
    }
}
