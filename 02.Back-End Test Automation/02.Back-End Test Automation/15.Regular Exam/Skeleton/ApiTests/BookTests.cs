using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class BookTests : IDisposable
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
        public void Test_GetAllBooks()
        {
            var request = new RestRequest("book", Method.Get);
            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var books = JArray.Parse(response.Content);
                Assert.That(books.Type, Is.EqualTo(JTokenType.Array), "Expected response content to be a JSON array");
                Assert.That(books.Count, Is.GreaterThan(0), "Expected at least one book in the response");

                foreach (var book in books)
                {
                    Assert.That(book["title"]?.ToString(), Is.Not.Null.And.Not.Empty, "Book title should not be null or empty");
                    Assert.That(book["author"]?.ToString(), Is.Not.Null.And.Not.Empty, "Book author should not be null or empty");
                    Assert.That(book["description"]?.ToString(), Is.Not.Null.And.Not.Empty, "Book description should not be null or empty");
                    Assert.That(book["price"]?.ToString(), Is.Not.Null.And.Not.Empty, "Book price should not be null or empty");
                    Assert.That(book["pages"]?.ToString(), Is.Not.Null.And.Not.Empty, "Book pages should not be null or empty");
                    Assert.That(book["category"]?.ToString(), Is.Not.Null.And.Not.Empty, "Book category should not be null or empty");
                }
            });
        }

        [Test]
        public void Test_GetBookByTitle()
        {
            var request = new RestRequest("book", Method.Get);
            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

                var books = JArray.Parse(response.Content);
                var book = books.FirstOrDefault(b => b["title"]?.ToString() == "The Great Gatsby");

                Assert.That(book, Is.Not.Null, "Book with title 'The Great Gatsby' not found");
                Assert.That(book["author"]?.ToString(), Is.EqualTo("F. Scott Fitzgerald"), "Book author should match expected value");
            });
        }

        [Test]
        public void Test_AddBook()
        {
            var getCategoriesRequest = new RestRequest("category", Method.Get);
            var getCategoriesResponse = client.Execute(getCategoriesRequest);

            var categories = JArray.Parse(getCategoriesResponse.Content);
            var category = categories.First();
            var categoryId = category["_id"]?.ToString();

            var request = new RestRequest("book", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");

            var title = "New Book Title";
            var author = "New Author";
            var description = "This is a new book description.";
            var price = 19.99;
            var pages = 250;
            request.AddJsonBody(new
            {
                title,
                author,
                description,
                price,
                pages,
                category = categoryId
            });

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");
            });

            var createdBook = JObject.Parse(response.Content);
            Assert.That(createdBook["_id"]?.ToString(), Is.Not.Empty, "Created book didn't have an Id.");

            var createdBookId = createdBook["_id"].ToString();

            var getBookRequest = new RestRequest("book/{id}", Method.Get);
            getBookRequest.AddUrlSegment("id", createdBookId);
            var getBookResponse = client.Execute(getBookRequest);

            Assert.Multiple(() =>
            {
                Assert.That(getBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(getBookResponse.Content, Is.Not.Empty, "Response content should not be empty");

                var book = JObject.Parse(getBookResponse.Content);
                Assert.That(book["title"]?.ToString(), Is.EqualTo(title), "Book title should match the input");
                Assert.That(book["author"]?.ToString(), Is.EqualTo(author), "Book author should match the input");
                Assert.That(book["description"]?.ToString(), Is.EqualTo(description), "Book description should match the input");
                Assert.That(book["price"]?.ToObject<double>(), Is.EqualTo(price), "Book price should match the input");
                Assert.That(book["pages"]?.ToObject<int>(), Is.EqualTo(pages), "Book pages should match the input");
                Assert.That(book["category"], Is.Not.Empty, "The category should not be empty");
                Assert.That(book["category"]?["_id"]?.ToString(), Is.EqualTo(categoryId), "Book category should match the input");
            });
        }

        [Test]
        public void Test_UpdateBook()
        {           
            var getRequest = new RestRequest("book", Method.Get);
            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
            Assert.That(getResponse.Content, Is.Not.Empty, "Get books response content should not be empty");
          
            var books = JArray.Parse(getResponse.Content);
            var bookToUpdate = books.FirstOrDefault(b => b["title"]?.ToString() == "The Catcher in the Rye");

            Assert.That(bookToUpdate, Is.Not.Null, "Book with title 'The Catcher in the Rye' not found");

            var bookId = bookToUpdate["_id"]?.ToString();
           
            var updateRequest = new RestRequest("book/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", bookId);
            updateRequest.AddJsonBody(new
            {
                title = "Updated Book Title",
                author = "Updated Author"
            });

            var updateResponse = client.Execute(updateRequest);

            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
            Assert.That(updateResponse.Content, Is.Not.Empty, "Update response content should not be empty");
           
            var updatedBook = JObject.Parse(updateResponse.Content);

            Assert.That(updatedBook["title"]?.ToString(), Is.EqualTo("Updated Book Title"), "Book title did not update correctly");
            Assert.That(updatedBook["author"]?.ToString(), Is.EqualTo("Updated Author"), "Book author did not update correctly");
        }

        [Test]
        public void Test_DeleteBook()
        {
            
            var getRequest = new RestRequest("book", Method.Get);
            var getResponse = client.Execute(getRequest);

            Assert.Multiple(() =>
            {
                Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK (200)");
                Assert.That(getResponse.Content, Is.Not.Empty, "Get books response content should not be empty");
            });
          
            var books = JArray.Parse(getResponse.Content);
            var bookToDelete = books.FirstOrDefault(b => b["title"]?.ToString() == "To Kill a Mockingbird");

            Assert.That(bookToDelete, Is.Not.Null, "Book with title 'To Kill a Mockingbird' not found");

            var bookId = bookToDelete["_id"]?.ToString();
           
            var deleteRequest = new RestRequest("book/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", bookId);

            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected status code OK for delete request");
          
            var verifyGetRequest = new RestRequest("book/{id}", Method.Get);
            verifyGetRequest.AddUrlSegment("id", bookId);

            var verifyGetResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyGetResponse.Content, Is.Null.Or.EqualTo("null"), "Deleted book should no longer exist");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
