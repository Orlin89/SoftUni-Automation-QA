using NUnit.Framework.Internal;
using RestSharpServices;
using System.Linq.Expressions;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        string repoName = "test-nakov-repo";
        int lastCreatedIssueNumber;
        long lastCreatedCommentId;


        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "username", "token");
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
            //Act
            var issues = client.GetAllIssues(repoName);

            //Assert
            Assert.That(issues, Has.Count.GreaterThan(0), "There should be more than one issue");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issues ID should be bigger than 0");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be bigger than 0");
                Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty");
            }
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            int issueNumber = 1;

            //Act
            var issue = client.GetIssueByNumber(repoName,
                issueNumber);

            //Assert
            Assert.IsNotNull(issue, "The data from the response should not be null");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0");
            Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0");
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            //Arrange 
            int issueNumber = 6;

            //Act
            var labels = client.GetAllLabelsForIssue(repoName, issueNumber);

            //Assert
            Assert.That(labels, Has.Count.GreaterThan(0), "Labels count should be greater than 0");

            foreach (var label in labels) {
                Assert.Multiple(() =>
                {
                    Assert.That(label.Id, Is.GreaterThan(0), "Label id should be bigger than 0");
                    Assert.That(label.Name, Is.Not.Empty, "Label name should not be empty");
                });

                Console.WriteLine("Label: " + label.Id + " - Name: " + label.Name);
            }
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            int issueNumber = 6;

            //Act
            var comments = client.GetAllCommentsForIssue(repoName,issueNumber);

            //Assert
            Assert.That(comments, Has.Count.GreaterThan(0), "Comments count should be bigger than 0");

            foreach (var comment in comments)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be greater than 0");
                    Assert.That(comment.Body, Is.Not.Empty, "Comment body should not be empty");
                });

                Console.WriteLine("Comment: " + comment.Id + " - Body: " + comment.Body);
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            //Arrange 
            string title = "Some Random Titlte";
            string body = "Some Random Body";

            //Act
            var issue = client.CreateIssue(repoName, title, body);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.EqualTo(title));
                Assert.That(issue.Body, Is.EqualTo(body));
            });

            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            //Arrange 
            var commentBody = "Some comment";

            //Act
            var comment = client.CreateCommentOnGitHubIssue(repoName, lastCreatedIssueNumber, commentBody);

            //Assert
            Assert.That(comment.Body, Is.EqualTo(commentBody));

            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;
        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            //Act
            var comment = client.GetCommentById(repoName, lastCreatedCommentId);

            //Assert
            Assert.IsNotNull(comment);
            Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId));
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            //Arrange 
            string newBody = "udpatedBody";

            //Act
            var comment = client.EditCommentOnGitHubIssue(repoName, lastCreatedCommentId, newBody);

            //Asserts
            Assert.IsNotNull(comment);
            Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId));
            Assert.That(comment.Body, Is.EqualTo(newBody));
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            //Act
            var result = client.DeleteCommentOnGitHubIssue(repoName, lastCreatedCommentId);

            //Asserts
            Assert.IsTrue(result, "The comment should be successfully deleted");

        }


    }
}

