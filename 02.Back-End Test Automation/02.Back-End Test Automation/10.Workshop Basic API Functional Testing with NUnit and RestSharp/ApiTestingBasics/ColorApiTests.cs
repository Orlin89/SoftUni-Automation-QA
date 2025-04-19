using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTestingBasics
{
    public class ColorApiTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");
            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test, Order(1)]
        public void Test_GetAllColors()
        {
            var request = new RestRequest("color", Method.Get);

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var colors = JArray.Parse(response.Content);

                Assert.That(colors.Type, Is.EqualTo(JTokenType.Array),
                    "Expected response content to be a JSON array");
                Assert.That(colors.Count, Is.GreaterThan(0), "Expected at least one color in the response");

                var colorTitles = colors.Select(c => c["title"]?.ToString()).ToList();
                Assert.That(colorTitles, Does.Contain("Black"), "Expected color 'Black'");
                Assert.That(colorTitles, Does.Contain("White"), "Expected color 'White'");
                Assert.That(colorTitles, Does.Contain("Red"), "Expected color 'Red'");

                foreach (var color in colors)
                {
                    Assert.That(color["_id"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Color ID should not be null or empty");
                    Assert.That(color["title"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Color title should not be null or empty");
                }

                Assert.That(colors.Count, Is.EqualTo(10), "Expected exactly 10 colors in the response");
            });
        }

        [Test, Order(2)]
        public void Test_AddColor()
        {
            var request = new RestRequest("color", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new { title = "New Color" });

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var content = JObject.Parse(response.Content);

                Assert.That(content["_id"]?.ToString(), Is.Not.Null.And.Not.Empty,
                    "Color ID should not be null or empty");
                Assert.That(content["title"]?.ToString(), Is.EqualTo("New Color"),
                    "Color title should match the input");

                Assert.That(content.ContainsKey("createdAt"), Is.True, "Color should have a createdAt field");
                Assert.That(content.ContainsKey("updatedAt"), Is.True, "Color should have an updatedAt field");

                Assert.That(DateTime.TryParse(content["createdAt"]?.ToString(), out _), Is.True,
                    "createdAt should be a valid date-time format");
                Assert.That(DateTime.TryParse(content["updatedAt"]?.ToString(), out _), Is.True,
                    "updatedAt should be a valid date-time format");

                Assert.That(content["createdAt"]?.ToString(), Is.EqualTo(content["updatedAt"]?.ToString()),
                    "createdAt and updatedAt should be the same on creation");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateColor()
        {
            var getRequest = new RestRequest("color", Method.Get);

            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve colors");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get colors response content is empty");

            var colors = JArray.Parse(getResponse.Content);
            var colorToUpdate = colors.FirstOrDefault(c => c["title"]?.ToString() == "New Color");

            Assert.That(colorToUpdate, Is.Not.Null, "Color with title 'Red' not found");

            var colorId = colorToUpdate["_id"]?.ToString();

            var updateRequest = new RestRequest("color/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", colorId);
            updateRequest.AddJsonBody(new { title = "Updated Red" });
            Thread.Sleep(1000);

            var updateResponse = client.Execute(updateRequest);

            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(updateResponse.Content, Is.Not.Empty, "Response content should not be empty");

                var content = JObject.Parse(updateResponse.Content);

                Assert.That(content["_id"]?.ToString(), Is.EqualTo(colorId),
                    "Color ID should match the updated color's ID");
                Assert.That(content["title"]?.ToString(), Is.EqualTo("Updated Red"),
                    "Color title should be updated correctly");
                Assert.That(content.ContainsKey("createdAt"), Is.True, "Color should have a createdAt field");
                Assert.That(content.ContainsKey("updatedAt"), Is.True, "Color should have an updatedAt field");
                Assert.That(DateTime.TryParse(content["createdAt"]?.ToString(), out _), Is.True,
                    "createdAt should be a valid date-time format");
                Assert.That(DateTime.TryParse(content["updatedAt"]?.ToString(), out _), Is.True,
                    "updatedAt should be a valid date-time format");
                Assert.That(content["updatedAt"]?.ToString(), Is.Not.EqualTo(content["createdAt"]?.ToString()),
                    "updatedAt should be different from createdAt after an update");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteColor()
        {
            var getRequest = new RestRequest("color", Method.Get);

            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to retrieve colors");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get colors response content is empty");

            var colors = JArray.Parse(getResponse.Content);
            var colorToDelete = colors.FirstOrDefault(c => c["title"]?.ToString() == "Updated Red");

            Assert.That(colorToDelete, Is.Not.Null, "Color with title 'Black' not found");

            var colorId = colorToDelete["_id"]?.ToString();

            var deleteRequest = new RestRequest("color/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", colorId);

            var deleteResponse = client.Execute(deleteRequest);

            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200) after deletion");

                var verifyGetRequest = new RestRequest("color/{id}", Method.Get);
                verifyGetRequest.AddUrlSegment("id", colorId);
                var verifyGetResponse = client.Execute(verifyGetRequest);

                Assert.That(verifyGetResponse.Content, Is.Empty.Or.EqualTo("null"),
                    "Verify get response content should be empty or 'null'");

                var refreshedGetResponse = client.Execute(getRequest);
                var refreshedColors = JArray.Parse(refreshedGetResponse.Content);
                var colorExists = refreshedColors.Any(c => c["title"]?.ToString() == "Updated Red");

                Assert.That(colorExists, Is.False,
                    "Color with title 'Black' should no longer exist in the list");
            });
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
