using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTestingBasics
{
    [TestFixture]
    public class BlogApiTests : IDisposable
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
        public void Test_GetAllBlogs()
        {
            //Arrange
            var request = new RestRequest("blog", Method.Get);

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not OK");
                Assert.That(response.Content, Is.Not.Empty, "Response content is empty");

                var blogs = JArray.Parse(response.Content);

                Assert.That(blogs.Count, Is.GreaterThan(1));

                foreach (var blog in blogs)
                {
                    Assert.That(blog["title"]?.ToString(), Is.Not.Null.And.Not.Empty);

                    Assert.That(blog["description"]?.ToString(), Is.Not.Null.And.Not.Empty);

                    Assert.That(blog["author"]?.ToString(), Is.Not.Null.And.Not.Empty);

                    Assert.That(blog["category"]?.ToString(), Is.Not.Null.And.Not.Empty);
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddBlog() 
        {
            //Arrange
            var request = new RestRequest("blog", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "New Blog Title",
                description = "New description",
                category = "test"
            });

            //Act
            var response = client.Execute(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JObject.Parse(response.Content);

                Assert.That(content["title"].ToString(), Is.EqualTo("New Blog Title"));
                Assert.That(content["description"].ToString(), Is.EqualTo("New description"));
                Assert.That(content["category"].ToString(), Is.EqualTo("test"));
                Assert.That(content["author"].ToString(), Is.Not.Null.And.Not.Empty);
            });
        }

        [Test, Order(3)]
        public void Test_UpdateBlog()
        {
            //Arrange
            var request = new RestRequest("blog", Method.Get);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not OK");
            Assert.That(response.Content, Is.Not.Empty, "Response content is empty");

            var blogs = JArray.Parse(response.Content);
            var blogtoUpdate = blogs.FirstOrDefault(b => b["title"].ToString() == "New Blog Title");

            var blogId = blogtoUpdate["_id"].ToString();

            var udpateRequest = new RestRequest("blog/{id}", Method.Put);
            udpateRequest.AddUrlSegment("id", blogId);
            udpateRequest.AddHeader("Authorization", $"Bearer {token}");
            udpateRequest.AddJsonBody(new
            {
                title = "Updated Blog Title",
                description = "Updated description",
                category = "updated test"
            });

            //Act
            var updatedResponse = client.Execute(udpateRequest);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(updatedResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(updatedResponse.Content, Is.Not.Empty);

                var content = JObject.Parse(updatedResponse.Content);

                Assert.That(content["title"].ToString(), Is.EqualTo("Updated Blog Title"));
                Assert.That(content["description"].ToString(), Is.EqualTo("Updated description"));
                Assert.That(content["category"].ToString(), Is.EqualTo("updated test"));
                Assert.That(content["author"].ToString(), Is.Not.Null.And.Not.Empty);
            });
        }

        [Test, Order(4)]
        public void Test_DeleteBlog()
        {
            //Arrange
            var getRequest = new RestRequest("blog", Method.Get);
            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not OK");
            Assert.That(getResponse.Content, Is.Not.Empty, "Response content is empty");

            var blogs = JArray.Parse(getResponse.Content);
            var blogToDelete = blogs.FirstOrDefault(p => p["title"]?.ToString() == "Updated Blog Title");

            Assert.That(blogToDelete, Is.Not.Null);

            var blogId = blogToDelete["_id"]?.ToString();

            var deleteRequest = new RestRequest("blog/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", blogId);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            //Act
            var deleteResponse = client.Execute(deleteRequest);

            //Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var verifyGetRequest = new RestRequest("blog/{id}", Method.Get);
            verifyGetRequest.AddUrlSegment("id", blogId);

            var verifyResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyResponse.Content, Is.EqualTo("null"));
        }
    }
}
