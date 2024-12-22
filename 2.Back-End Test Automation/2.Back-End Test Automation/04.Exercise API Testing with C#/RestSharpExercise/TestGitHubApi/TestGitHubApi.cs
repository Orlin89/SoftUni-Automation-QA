using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        int lastCreatedIssueNumber;
        long lastCreatedCommentId;
        

        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "Orlin89", "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");
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
            string repo = "test-nakov-repo";
            var issues = client.GetAllIssues(repo);

            Assert.That(issues, Has.Count.GreaterThan(1), "There should be more than one issue.");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greate than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0.");
                Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty.");
            }
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            string repo = "test-nakov-repo";
            int issueNumber = 1;
            var issue = client.GetIssueByNumber(repo, issueNumber);

            Assert.IsNotNull(issue, "The response should contain issue data.");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber), "The issue NUmber should match the requested number.");
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            string repo = "test-nakov-repo";
            int issueNumber = 6;
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            Assert.That(labels.Count, Is.GreaterThan(0));

            foreach(var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0), "Label ID should be greater than 0.");
                Assert.That(label.Name, Is.Not.Empty, "Label Name should not be empty.");
                
                Console.WriteLine("Label: " + label.Id + " - Name: " + label.Name);
            }
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            string repo = "test-nakov-repo";
            int issueNumber = 6;
            var comments = client.GetAllCommentsForIssue(repo,issueNumber);

            Assert.That(comments.Count, Is.GreaterThan(0));

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be greater than 0.");
                Assert.That(comment.Body, Is.Not.Empty, "Comment body should not be empty.");

                Console.WriteLine("Comment: " + comment.Id + " - body: " + comment.Body);
            }

        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            string repo = "test-nakov-repo";
            string expectedTitle = "My first created issue in GitHub.";
            string body = "Some body for the first issue.";

            var issue = client.CreateIssue(repo, expectedTitle, body);

            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.Not.Empty);
                Assert.That(issue.Title, Is.EqualTo(expectedTitle));                           
            });

            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            string repo = "test-nakov-repo";
            int issueNumber = lastCreatedIssueNumber;
            Console.WriteLine(issueNumber);
            string expectedBody = "New created body for created issue by me.";

            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, expectedBody);
            Assert.That(comment.Body, Is.EqualTo(expectedBody));
            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;
        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            string repo = "test-nakov-repo";
            long commentId = lastCreatedCommentId;

            Comment comment = client.GetCommentById(repo, commentId);
            Assert.IsNotNull(comment, "Expected to retrive comment, but got null.");
            Assert.That(comment.Id, Is.EqualTo(commentId), "The retrived comment ID should match the requested comment ID.");
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            string repo = "test-nakov-repo";
            long commentId = lastCreatedCommentId;
            string newBody = "This is new body";

            var updatedComment = client.EditCommentOnGitHubIssue(repo, commentId, newBody);

            Assert.IsNotNull(updatedComment, "The updated comment should not be null.");
            Assert.That(updatedComment.Id, Is.EqualTo(commentId), "The updated comment ID should match the original comment ID.");
            Assert.That(updatedComment.Body, Is.EqualTo(newBody), "The updated comment text should match the new body text.");
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            string repo = "test-nakov-repo";
            long commentId = lastCreatedCommentId;

            bool result = client.DeleteCommentOnGitHubIssue(repo, commentId);

            Assert.IsTrue(result, "The comment should be successfully deleted.");
        }
    }
}

