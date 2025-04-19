using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTestingBasics
{
    public class CouponApiTests : IDisposable
    {
        private RestClient client;
        private string token;

        public void Dispose()
        {
            client?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");
            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test, Order(1)]
        public void Test_GetAllCoupons()
        {
            var request = new RestRequest("coupon", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var coupons = JArray.Parse(response.Content);

                Assert.That(coupons.Type, Is.EqualTo(JTokenType.Array),
                    "Expected response content to be a JSON array");
                Assert.That(coupons.Count, Is.GreaterThan(0),
                    "Expected at least one coupon in the response");

                var couponNames = coupons.Select(c => c["name"]?.ToString()).ToList();
                Assert.That(couponNames, Does.Contain("SUMMER21"), "Expected coupon 'SUMMER21'");
                Assert.That(couponNames, Does.Contain("WINTER21"), "Expected coupon 'WINTER21'");
                Assert.That(couponNames, Does.Contain("BLACKFRIDAY"), "Expected coupon 'BLACKFRIDAY'");

                foreach (var coupon in coupons)
                {
                    Assert.That(coupon["_id"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Coupon ID should not be null or empty");
                    Assert.That(coupon["name"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Coupon name should not be null or empty");
                    Assert.That(coupon["expiry"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Coupon expiry date should not be null or empty");
                    int discountValue = coupon["discount"].Value<int>();
                    Assert.That(discountValue, Is.GreaterThan(0),
                        "Coupon discount should be a positive integer");
                }

                foreach (var coupon in coupons)
                {
                    Assert.That(DateTime.TryParse(coupon["expiry"]?.ToString(), out var expiryDate),
                        Is.True, "Coupon expiry should be a valid date-time format");
                    Assert.That(expiryDate, Is.GreaterThan(DateTime.Now),
                        "Coupon expiry should be in the future");
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddCoupon()
        {
            var request = new RestRequest("coupon", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new { name = "NEW COUPON", discount = 20, expiry = "2026-12-31" });

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var content = JObject.Parse(response.Content);

                Assert.That(content["_id"]?.ToString(), Is.Not.Null.And.Not.Empty,
                    "Coupon ID should not be null or empty");
                Assert.That(content["name"]?.ToString(), Is.EqualTo("NEW COUPON"),
                    "Coupon name should match the input");
                Assert.That(content["discount"]?.Value<int>(), Is.EqualTo(20),
                    "Coupon discount should match the input");
                Assert.That(content["expiry"]?.ToString(), Is.EqualTo("12/31/2026 12:00:00 AM"),
                    "Coupon expiry should match the input");

                Assert.That(DateTime.TryParse(content["expiry"]?.ToString(), out var expiryDate),
                    Is.True, "Expiry should be a valid date-time format");
                Assert.That(expiryDate, Is.GreaterThan(DateTime.Now),
                    "Coupon expiry date should be in the future");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateCoupon()
        {
            var getRequest = new RestRequest("coupon", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");

            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve coupons");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get coupons response content is empty");

            var coupons = JArray.Parse(getResponse.Content);
            var couponToUpdate = coupons.FirstOrDefault(c => c["name"]?.ToString() == "NEW COUPON");

            Assert.That(couponToUpdate, Is.Not.Null, "Coupon with name 'NEW COUPON' not found");

            var couponId = couponToUpdate["_id"]?.ToString();

            var updateRequest = new RestRequest("coupon/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", couponId);
            updateRequest.AddJsonBody(new { name = "UPDATED COUPON", discount = 25, expiry = "2026-12-31" });

            var updateResponse = client.Execute(updateRequest);

            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200) after update");
                Assert.That(updateResponse.Content, Is.Not.Empty,
                    "Response content should not be empty after update");

                var updatedContent = JObject.Parse(updateResponse.Content);

                Assert.That(updatedContent["_id"]?.ToString(), Is.EqualTo(couponId),
                    "Coupon ID should not change after update");
                Assert.That(updatedContent["name"]?.ToString(), Is.EqualTo("UPDATED COUPON"),
                    "Coupon name should be updated");
                Assert.That(updatedContent["discount"]?.Value<int>(), Is.EqualTo(25),
                    "Coupon discount should be updated");
                Assert.That(updatedContent["expiry"]?.ToString(), Is.EqualTo("12/31/2026 12:00:00 AM"),
                    "Coupon expiry should be updated");

                Assert.That(DateTime.TryParse(updatedContent["expiry"]?.ToString(), out var expiryDate),
                    Is.True, "Expiry should be a valid date-time format");
                Assert.That(expiryDate, Is.GreaterThan(DateTime.Now),
                    "Coupon expiry date should be in the future");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteCoupon()
        {
            var getRequest = new RestRequest("coupon", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");

            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve coupons");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get coupons response content is empty");

            var coupons = JArray.Parse(getResponse.Content);
            var couponToDelete = coupons.FirstOrDefault(c => c["name"]?.ToString() == "UPDATED COUPON");

            Assert.That(couponToDelete, Is.Not.Null, "Coupon with name 'UPDATED COUPON' not found");

            var couponId = couponToDelete["_id"]?.ToString();

            var deleteRequest = new RestRequest("coupon/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", couponId);

            var deleteResponse = client.Execute(deleteRequest);

            Assert.Multiple(() =>
            {
                var verifyGetRequest = new RestRequest("coupon/{id}", Method.Get);
                verifyGetRequest.AddHeader("Authorization", $"Bearer {token}");
                verifyGetRequest.AddUrlSegment("id", couponId);

                var verifyGetResponse = client.Execute(verifyGetRequest);

                var verifyListResponse = client.Execute(getRequest);

                var updatedCoupons = JArray.Parse(verifyListResponse.Content);
                var deletedCoupon = updatedCoupons
                .FirstOrDefault(c => c["_id"]?.ToString() == couponId);

                Assert.That(deletedCoupon, Is.Null,
                    "Deleted coupon should not be present in the list of coupons");
            });
        }
    }
}
