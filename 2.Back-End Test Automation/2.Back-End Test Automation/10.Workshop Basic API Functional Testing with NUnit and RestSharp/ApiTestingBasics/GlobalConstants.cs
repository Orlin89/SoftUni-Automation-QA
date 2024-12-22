using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Net;

namespace ApiTestingBasics
{
    public class GlobalConstants
    {
        public const string BaseUrl = "http://localhost:5000/api";

        public static string AuthenticateUser(string email, string password)
        {
            var restClient = new RestClient(BaseUrl);
            var authRequest = new RestRequest("user/admin-login", Method.Post);
            authRequest.AddJsonBody(new { email, password });

            var response = restClient.Execute(authRequest);

            if (response.StatusCode != HttpStatusCode.OK)
            { 
                Assert.Fail($"Authentication failes with status code: {response.StatusCode}, and response content: {response.Content}");
            }

            var content = JObject.Parse(response.Content);
            return content["token"]?.ToString();
        }

        public static void UserWait()
        {
            Thread.Sleep(1000);
        }
    }
}
