using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ApiTests  
{
    [TestFixture]

    public class ProductApiTests : IDisposable
    {
       private RestClient client;
       private string token;

        public void Dispose()
        {
            client.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("admin@gmail.com", "admin@gmail.com");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test]
        public void Test_GetAllProducts()
        {
           var request = new RestRequest("product", Method.Get);
           var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JArray.Parse(response.Content);

                var productTitles = new[]
                {
                    "Smartphone Alpha", "Wireless Headphones"
                };

                foreach(var title in productTitles) 
                {
                    Assert.That(content.ToString(), Does.Contain(title));
                }

                var expectedPrice = new Dictionary<string, decimal>
                {
                   { "Smartphone Alpha", 999 },
                   { "Wireless Headphones", 199 },
                   { "Gaming Laptop", 1499 },
                   { "4K Ultra HD TV", 899 },
                   { "Smartwatch Pro", 299}
                };

                foreach(var product in content)
                {
                    var title = product["title"].ToString();
                    if(expectedPrice.ContainsKey(title))
                    {
                        Assert.That(product["price"].Value<decimal>(), Is.EqualTo(expectedPrice[title]));
                    }
                }
            });
        }

        [Test]
        public void Test_AddProduct() 
        {
            var request = new RestRequest("product", Method.Post);           
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new 
            {
               title = "New test product",
               slug = "new-test-product",
               description = "New Product Description",
               price = 99.99,
               category = "test",
               brand = "test",
               quantity = 100,
            });

            var response = client.Execute(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Content, Is.Not.Empty);

                var content = JObject.Parse(response.Content);

                Assert.That(content["title"].ToString(), Is.EqualTo("New test product"));
                Assert.That(content["slug"].ToString(), Is.EqualTo("new-test-product"));
                Assert.That(content["description"].ToString(), Is.EqualTo("New Product Description"));
                Assert.That(content["price"].Value<decimal>(), Is.EqualTo(99.99));
                Assert.That(content["category"].ToString(), Is.EqualTo("test"));
                Assert.That(content["brand"].ToString(), Is.EqualTo("test"));
                Assert.That(content["quantity"].Value<decimal>(), Is.EqualTo(100));
            });
        }

        [Test]
        public void Test_UpdateProduct_InvalidProductId()
        {
            var invalidProductId = "yhfer77347hffdshyu";

            var updateRequest = new RestRequest("product/{id}", Method.Put);
            updateRequest.AddUrlSegment("id", invalidProductId);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new
            {
                title = "Update test product",
                description = "Update Product Description",
                price = 99.99,
                brand = "test",
                quantity = 100,
            });

            var updateResponse = client.Execute(updateRequest);
            var updateContent = JObject.Parse(updateResponse.Content);

            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError).Or.EqualTo(HttpStatusCode.BadRequest),
                    "Expected 404 not found or 500 bad request for invalid product ID");

                Assert.That(updateContent["message"].ToString(), Does.Contain("This id is not valid or not Found").Or.Contain("Invalid ID"), 
                    "Expected an error message indicating the product ID is invalid or not found");
            });
        }

        [Test]
        public void Test_DeleteProduct()
        {
            var getRequest = new RestRequest("product", Method.Get);
            var getResponse = client.Execute(getRequest);

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(getResponse.Content, Is.Not.Empty);

            var products = JArray.Parse(getResponse.Content);
            var productToDelete = products.FirstOrDefault(p => p["slug"]?.ToString() == "new-test-product");

            Assert.That(productToDelete, Is.Not.Null, "Product with slug 'new-test-product' not found");

            var productId = productToDelete["_id"]?.ToString();

            var deleteRequest = new RestRequest("product/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", productId);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var verifyGetRequest = new RestRequest("product/{id}", Method.Delete);
            verifyGetRequest.AddUrlSegment("id", productId);           
            var verifyGetResponse = client.Execute(verifyGetRequest);

            Assert.That(verifyGetResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}
