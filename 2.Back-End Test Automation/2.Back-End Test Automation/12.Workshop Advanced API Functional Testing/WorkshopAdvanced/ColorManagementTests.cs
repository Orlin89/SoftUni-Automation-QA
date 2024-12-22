using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;

namespace WorkshopAdvanced
{
    [TestFixture]
    public class ColorManagementTests
    {
        private RestClient client;
        private string adminToken;
        private Random random;

        [TearDown]
        public void Dispose()
        {
            client.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            adminToken = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");
            random = new Random();
        }

        [Test]
        public void ColorLifecycleTest()
        {
            //Create new color with random title
            var addColorRequest = new RestRequest($"/color", Method.Post);
            addColorRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            addColorRequest.AddJsonBody(new
            {
                Title = "Color" + random.Next(999, 9999).ToString()
            });

            var addColorResponse = client.Execute(addColorRequest);
            Assert.That(addColorResponse.IsSuccessful, Is.True, "Adding color to product failed");

            //Exctract color id
            var colorId = JObject.Parse(addColorResponse.Content)["_id"]?.ToString();
            Assert.That(colorId, Is.Not.Null.Or.Empty, "Color ID should not be null or empty");

            //Get the created color and assert
            var getColorRequest = new RestRequest($"/color/{colorId}", Method.Get);
            var getColorResponse = client.Execute(getColorRequest);
            Assert.That(getColorResponse.IsSuccessful, Is.True, "Failed to retrieve product color");

            //Delete the color by its ID
            var deleteColorRequest = new RestRequest($"/color/{colorId}", Method.Delete);
            deleteColorRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            var deleteColorResponse = client.Execute(deleteColorRequest);
            Assert.That(deleteColorResponse.IsSuccessful, Is.True, "Deleting product color failed");

            //Verify by get Request the color is deleted
            var verifyColorRequest = new RestRequest($"/color/{colorId}", Method.Get);
            var verifyColorResponse = client.Execute(verifyColorRequest);
            Assert.That(verifyColorResponse.Content, Is.Null.Or.EqualTo("null"), 
                "Color still exists after deletion");
        }

        [Test]
        public void ColorLifecycleNegativeTest()
        {
            //Create color with invalid user token
            var invalidToken = "InvalidToken";

            var addColorRequest = new RestRequest($"/color", Method.Post);
            addColorRequest.AddHeader("Authorization", $"Bearer {invalidToken}");
            addColorRequest.AddJsonBody(new
            {
                Title = "Turquoise"
            });

            var addColorResponse = client.Execute(addColorRequest);

            Assert.That(addColorResponse.IsSuccessful, Is.False, 
                "Adding color should have failed with an invalid token");
            Assert.That(addColorResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError),
                "Expected internal server error status when using invalid token");

            //Get color by invalid id and assert it fails
            var invalidColorId = "invalidColorId";
            var getColorRequest = new RestRequest($"/color/{invalidColorId}", Method.Get);
            var getColorResponse = client.Execute(getColorRequest);

            Assert.That(getColorResponse.IsSuccessful, Is.False, 
                "Retrieving color should fail for an invalid color ID");
            Assert.That(getColorResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError),
                "Expected internal server error status for an invalid color ID");

            //Delete color with invalid id and token and assert fails
            var deleteColorRequest = new RestRequest($"/color/{invalidColorId}", Method.Delete);
            deleteColorRequest.AddHeader("Authorization", $"Bearer {invalidToken}");
            var deleteColorResponse = client.Execute(deleteColorRequest);

            Assert.That(deleteColorResponse.IsSuccessful, Is.False, 
                "Deleting color should fail with an invalid token");
            Assert.That(deleteColorResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError),
                "Expected internal server error status when using invalid token to delete color");
        }
    }
}
