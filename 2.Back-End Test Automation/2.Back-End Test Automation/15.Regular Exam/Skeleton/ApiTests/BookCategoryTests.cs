using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class BookCategoryTests : IDisposable
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
        public void Test_BookCategoryLifecycle()
        {
            // Step 1: Create a new book category
            var createRequest = new RestRequest("category", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new { title = "Fictional Literature" });

            var createResponse = client.Execute(createRequest);
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Category creation failed");

            var createdCategory = JObject.Parse(createResponse.Content);
            var categoryId = createdCategory["_id"]?.ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty, "Category ID should not be null or empty");
            Assert.That(createdCategory["title"]?.ToString(), Is.EqualTo("Fictional Literature"), "Category title mismatch after creation");

            // Step 2: Retrieve all book categories and verify the newly created category is present
            var getAllRequest = new RestRequest("category", Method.Get);           

            var getAllResponse = client.Execute(getAllRequest);
            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to retrieve categories");
            Assert.That(getAllResponse.Content, Is.Not.Empty, "Category list should not be empty");
            
            var allCategories = JArray.Parse(getAllResponse.Content);           
            
            Assert.That(allCategories?.Type, Is.EqualTo(JTokenType.Array), "The response should be a JSON array");
            Assert.That(allCategories.Count, Is.GreaterThan(0), "Category list should have at least one category");
            Assert.That(allCategories.Any(c => c["_id"]?.ToString() == categoryId), "Newly created category not found in the list");

            // Step 3: Update the category title
            var updateRequest = new RestRequest($"category/{categoryId}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new { title = "Updated Fictional Literature" });

            var updateResponse = client.Execute(updateRequest);
            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Category update failed");

            // Step 4: Verify that the category details have been updated
            var getUpdatedRequest = new RestRequest($"category/{categoryId}", Method.Get);           

            var getUpdatedResponse = client.Execute(getUpdatedRequest);
            Assert.That(getUpdatedResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Failed to retrieve updated category");
            Assert.That(getUpdatedResponse.Content, Is.Not.Empty, "The response content should not be empty");
            var updatedCategory = JObject.Parse(getUpdatedResponse.Content);
            Assert.That(updatedCategory["title"]?.ToString(), Is.EqualTo("Updated Fictional Literature"), "Category title was not updated correctly");

            // Step 5: Delete the category and validate it's no longer accessible 
            var deleteRequest = new RestRequest($"category/{categoryId}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Category deletion failed");

            var validateDeletedRequest = new RestRequest($"category/{categoryId}", Method.Get);           

            var validateDeletedResponse = client.Execute(validateDeletedRequest);           
            Assert.That(validateDeletedResponse.Content, Is.EqualTo("null"), "Deleted category content should be null");

            // Step 6: Verify that the deleted category cannot be found
            var getDeletedRequest = new RestRequest($"category/{categoryId}", Method.Get);     

            var getDeletedResponse = client.Execute(getDeletedRequest);           
            Assert.That(getDeletedResponse.Content, Is.EqualTo("null"), "Deleted category content should be null");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
