using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class RecipeTests : IDisposable
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
        public void Test_GetAllRecipes()
        {
        }

        [Test]
        public void Test_GetRecipeByTitle()
        {
        }

        [Test]
        public void Test_AddRecipe()
        {
        }

        [Test]
        public void Test_UpdateRecipe()
        {
        }

        [Test]
        public void Test_DeleteRecipe()
        {
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
