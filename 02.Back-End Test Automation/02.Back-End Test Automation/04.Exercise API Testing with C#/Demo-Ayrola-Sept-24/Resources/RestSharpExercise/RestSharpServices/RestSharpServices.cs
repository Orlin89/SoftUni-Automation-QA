using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpServices.Models;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace RestSharpServices
{
    public class GitHubApiClient
    {
        private RestClient client;

        public GitHubApiClient(string baseUrl, string username, string token)
        {
            var options = new RestClientOptions(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(username, token)
            };

            this.client = new RestClient(options);
        }

        public List<Issue>  GetAllIssues(string repo)
        {
            var request = new RestRequest($"{repo}/issues", Method.Get);

            var response = client.Execute(request);

            var issues = response.Content != null ?JsonConvert.DeserializeObject<List<Issue>>(response.Content) : null;

            return issues;
        }

        public Issue  GetIssueByNumber(string repo, int issueNumber)
        {
            var request = new RestRequest($"{repo}/issues/{issueNumber}", Method.Get);

            var response = client.Execute(request);

            var issue = response.Content != null ? JsonConvert.DeserializeObject<Issue>(response.Content) : null;

            return issue;
        }

        public Issue  CreateIssue(string repo, string title, string body)
        {
            var request = new RestRequest($"{repo}/issues", Method.Post);
            request.AddBody(new { title, body });

            var response = client.Execute(request);

            var issue = response.Content != null ? JsonConvert.DeserializeObject<Issue>(response.Content) : null;

            return issue;
        }

        public List<Label>  GetAllLabelsForIssue(string repo, int issueNumber)
        {
            var request = new RestRequest($"{repo}/issues/{issueNumber}/labels", Method.Get);

            var response = client.Execute(request);

            var labels = response.Content != null ? JsonConvert.DeserializeObject<List<Label>>(response.Content) : null;

            return labels;
        }

        public List<Comment>  GetAllCommentsForIssue(string repo, int issueNumber)
        {
            var request = new RestRequest($"{repo}/issues/{issueNumber}/comments", Method.Get);

            var response = client.Execute(request);

            var comments = response.Content != null ? JsonConvert.DeserializeObject<List<Comment>>(response.Content) : null;

            return comments;
        }

        public Comment CreateCommentOnGitHubIssue(string repo, int issueNumber, string body)
        {
            var request = new RestRequest($"{repo}/issues/{issueNumber}/comments", Method.Post);
            request.AddBody(new { body });

            var response = client.Execute(request);

            var comment = response.Content != null ? JsonConvert.DeserializeObject<Comment>(response.Content) : null;

            return comment;
        }

        public Comment  GetCommentById (string repo, long commentId)
        {
            var request = new RestRequest($"{repo}/issues/comments/{commentId}", Method.Get);

            var response = client.Execute(request);

            var comment = response.Content != null ? JsonConvert.DeserializeObject<Comment>(response.Content) : null;

            return comment;
        }

        public Comment  EditCommentOnGitHubIssue( string repo, long commentId, string newBody)
        {
            var request = new RestRequest($"{repo}/issues/comments/{commentId}", Method.Patch);
            request.AddBody(new { body = newBody });

            var response = client.Execute(request);

            var comment = response.Content != null ? JsonConvert.DeserializeObject<Comment>(response.Content) : null;

            return comment;
        }

        public bool DeleteCommentOnGitHubIssue(string repo, long commentId)
        {
            var request = new RestRequest($"{repo}/issues/comments/{commentId}", Method.Delete);

            var response = client.Execute(request);

            return response.IsSuccessful;
        }

    }
}
