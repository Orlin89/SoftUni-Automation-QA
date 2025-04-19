using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class DestinationTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("john.doe@example.com", "password123");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test]
        public void Test_GetAllDestinations()
        {
            var request = new RestRequest("destination", Method.Get);

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var destinations = JArray.Parse(response.Content);

                Assert.That(destinations.Type, Is.EqualTo(JTokenType.Array),
                    "Expected response content to be a JSON array");
                Assert.That(destinations.Count, Is.GreaterThan(0), "Expected at least one destination in the response");

                foreach (var destination in destinations)
                {
                    Assert.That(destination["name"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Destination name should not be null or empty");
                    Assert.That(destination["location"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Destination location should not be null or empty");
                    Assert.That(destination["description"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Destination description should not be null or empty");
                    Assert.That(destination["category"]?.ToString(), Is.Not.Null.And.Not.Empty,
                        "Destination category should not be null or empty");
                    Assert.That(destination["bestTimeToVisit"]?.ToString(), Is.Not.Null.And.Not.Empty, "Destination bestTimeToVisit should not be null or empty");
                    Assert.That(destination["attractions"]?.Type, Is.EqualTo(JTokenType.Array), "Expected Destination attractions content to be a JSON array");
                }
            });
        }

        [Test]
        public void Test_GetDestinationByName()
        {
            var request = new RestRequest("destination", Method.Get);

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var destinations = JArray.Parse(response.Content);
                var destination = destinations.FirstOrDefault(b => b["name"]?.ToString() == "New York City");

                Assert.That(destination["location"]?.ToString(), Is.EqualTo("New York, USA"),
                    "Destination location should not be null or empty");
                Assert.That(destination["description"]?.ToString(), Is.EqualTo("The largest city in the USA, known for its skyscrapers, culture, and entertainment."),
                    "Destination description should not be null or empty");
            });
        }

        [Test]
        public void Test_AddDestination()
        {
            var getCategoriesRequest = new RestRequest($"category", Method.Get);
            var getCategoriesResponse = client.Execute(getCategoriesRequest);

            var categories = JArray.Parse(getCategoriesResponse.Content);

            var category = categories.First();
            var categoryId = category["_id"]?.ToString();

            var request = new RestRequest("destination", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            var name = "Maui Beach";
            var location = "Hawaii, USA";
            var description = "A beautiful beach with crystal clear waters and white sands.";
            var bestTimeToVisit = "April to October";
            var attractionsArr = new[] { "Surfing", "Sunbathing", "Snorkeling" };
            request.AddJsonBody(new
            {
                name,
                location,
                description,
                attractions = attractionsArr,
                bestTimeToVisit,
                category = categoryId
            });

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");
            });

            var createdDestination = JObject.Parse(response.Content);
            Assert.That(createdDestination["_id"]?.ToString(), Is.Not.Empty, "Created book didn't have an Id.");

            var createdDestinationId = createdDestination["_id"].ToString();

            var getDestinationRequest = new RestRequest("destination/{id}", Method.Get);
            getDestinationRequest.AddUrlSegment("id", createdDestinationId);
            var getDestinationResponse = client.Execute(getDestinationRequest);

            Assert.Multiple(() =>
            {
                Assert.That(getDestinationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(getDestinationResponse.Content, Is.Not.Empty, "Response content should not be empty");

                var content = JObject.Parse(getDestinationResponse.Content);

                Assert.That(content["name"]?.ToString(), Is.EqualTo(name), "Destination name should match the input.");
                Assert.That(content["location"]?.ToString(), Is.EqualTo(location), "Destination location should match the input.");
                Assert.That(content["description"]?.ToString(), Is.EqualTo(description), "Destination description should match the input.");
                Assert.That(content["bestTimeToVisit"]?.ToString(), Is.EqualTo(bestTimeToVisit), "Destination bestTimeToVisit should match the input.");

                Assert.That(content["category"]?.ToString(), Is.Not.Null.And.Not.Empty, "Destination category should not be null or empty");
                Assert.That((string)content["category"]["_id"], Is.EqualTo(categoryId), $"Destination category should be '{categoryId}'");

                Assert.That(content["attractions"]?.Type, Is.EqualTo(JTokenType.Array), "Expected Destination attractions content to be a JSON array");
                Assert.That(content["attractions"].Count, Is.EqualTo(3), "Destination attractions did not have the correct number of elements.");

                Assert.That(content["attractions"][0]?.ToString(), Is.EqualTo(attractionsArr[0]), $"Destination attractions is missing element '{attractionsArr[0]}'");
                Assert.That(content["attractions"][1]?.ToString(), Is.EqualTo(attractionsArr[1]), $"Destination attractions is missing element '{attractionsArr[1]}'");
                Assert.That(content["attractions"][2]?.ToString(), Is.EqualTo(attractionsArr[2]), $"Destination attractions is missing element '{attractionsArr[2]}'");
            });
        }

        [Test]
        public void Test_UpdateDestination()
        {
            var getRequest = new RestRequest("destination", Method.Get);

            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to retrieve destinations");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get destinations response content is empty");

            var destinations = JArray.Parse(getResponse.Content);
            var destinationToUpdate = destinations.FirstOrDefault(b => b["name"]?.ToString() == "Machu Picchu");

            Assert.That(destinationToUpdate, Is.Not.Null, "Destination with name 'Machu Picchu' not found");

            var destinationId = destinationToUpdate["_id"].ToString();

            var updateRequest = new RestRequest("destination/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", destinationId);
            updateRequest.AddJsonBody(new
            {
                name = "Summer in Machu Picchu",
                bestTimeToVisit = "Summer!",
            });

            var updateResponse = client.Execute(updateRequest);

            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(updateResponse.Content, Is.Not.Empty, "Update response content should not be empty");

                var content = JObject.Parse(updateResponse.Content);

                Assert.That(content["name"]?.ToString(), Is.EqualTo("Summer in Machu Picchu"), "Destination name should match the updated value");
                Assert.That(content["bestTimeToVisit"]?.ToString(), Is.EqualTo("Summer!"), "Destination best time to visit should match the updated value");
            });
        }

        [Test]
        public void Test_DeleteDestination()
        {
            var getRequest = new RestRequest("destination", Method.Get);
            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to retrieve destinations");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get destinations response content is empty");

            var destinations = JArray.Parse(getResponse.Content);
            var destinationToDelete = destinations.FirstOrDefault(b => b["name"]?.ToString() == "Yellowstone National Park");

            Assert.That(destinationToDelete, Is.Not.Null, "Destination with name 'Yellowstone National Park' not found");

            var destinationId = destinationToDelete["_id"].ToString();

            var deleteRequest = new RestRequest("destination/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", destinationId);

            var deleteResponse = client.Execute(deleteRequest);

            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code Ok");

                var verifyGetRequest = new RestRequest("destination/{id}", Method.Get);
                verifyGetRequest.AddUrlSegment("id", destinationId);

                var verifyGetResponse = client.Execute(verifyGetRequest);

                Assert.That(verifyGetResponse.Content, Is.Null.Or.EqualTo("null"), "Verify get response content should be empty");
            });
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
