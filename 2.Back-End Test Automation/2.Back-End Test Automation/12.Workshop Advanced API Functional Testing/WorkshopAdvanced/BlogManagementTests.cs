using RestSharp;
using Newtonsoft.Json.Linq;

namespace WorkshopAdvanced
{
    [TestFixture]
    public class BlogManagementTests
    {
        private RestClient client;
        private string token;
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
            token = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");
            random = new Random();
        }

        [Test]
        public void BlogPostLifecycleTest()
        {
            //Creating a new blog
            var createBlogPostRequest = new RestRequest("/blog", Method.Post);
            createBlogPostRequest.AddHeader("Authorization", $"Bearer {token}");
            createBlogPostRequest.AddJsonBody(new
            {
                Title = "Blog_Post" + random.Next(999, 9999).ToString(),
                Description = "This is a new blog post content.",
                Category = "Technology"
            });

            var createBlogPostResponse = client.Execute(createBlogPostRequest);
            string blogPostId = JObject.Parse(createBlogPostResponse.Content)["id"]?.ToString();

            Assert.That(createBlogPostResponse.IsSuccessful, Is.True, "Blog post creation failed");
            Assert.That(blogPostId, Is.Not.Null.Or.Empty, "Blog post ID should not be null or empty");

            //Update the created blog and assert its updated
            var updateBlogPostRequest = new RestRequest($"/blog/{blogPostId}", Method.Put);
            updateBlogPostRequest.AddHeader("Authorization", $"Bearer {token}");
            updateBlogPostRequest.AddJsonBody(new
            {
                Title = "UpdatedBlogPost" + random.Next(999, 9999).ToString(),
                Description = "Updated blog post content."
            });

            var updateBlogPostResponse = client.Execute(updateBlogPostRequest);

            Assert.That(updateBlogPostResponse.IsSuccessful, Is.True, "Updating blog post failed");

            //Delete blog
            var deleteBlogPostRequest = new RestRequest($"/blog/{blogPostId}", Method.Delete);
            deleteBlogPostRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteBlogPostResponse = client.Execute(deleteBlogPostRequest);

            Assert.That(deleteBlogPostResponse.IsSuccessful, Is.True, "Deleting blog post failed");

            //Make get request to verify the blog is deleted
            var verifyBlogPostRequest = new RestRequest($"/blog/{blogPostId}", Method.Get);
            var verifyBlogPostResponse = client.Execute(verifyBlogPostRequest);

            Assert.That(verifyBlogPostResponse.Content, Is.Null.Or.EqualTo("null"), 
                "Blog post still exists after deletion");
        }
    }
}
