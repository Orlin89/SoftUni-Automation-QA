using NUnit.Framework;

using System;
using System.Collections.Generic;
//using TestApp.Store;

namespace TestApp.UnitTests;

public class ArticleTests
{
    // TODO: write the setup method
    private Article _article;
    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] input = new string[]{"Article Content Author",
            "Article2 Content2 Author2",
            "Article3 Content3 Author3"};
        

        // Act
        Article result = _article.AddArticles(input);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] sampleArticles = new string[]
        {
        "Zebra ContentA AuthorA",
        "Apple ContentB AuthorB",
        "Monkey ContentC AuthorC"
        };
        _article = _article.AddArticles(sampleArticles);

        // Act
        string result = _article.GetArticleList(_article, "title");

        // Assert
        string expected = $"Apple - ContentB: AuthorB" + Environment.NewLine +
            "Monkey - ContentC: AuthorC" + Environment.NewLine +
            "Zebra - ContentA: AuthorA";
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] sampleArticles = new string[]
        {
        "Zebra ContentA AuthorA",
        "Apple ContentB AuthorB",
        "Monkey ContentC AuthorC"
        };
        _article = _article.AddArticles(sampleArticles);

        // Act
        string result = _article.GetArticleList(_article, "tit");
        string expected = string.Empty;

        // Assert
        Assert.AreEqual(expected, result);
    }
}
