using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";
        List<string> expected = new List<string>();

        // Act
        List<string> actual = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "No url here";       

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        //Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string text = "https://abv.bg";
        List<string> expected = new List<string>() { "https://abv.bg" };

        // Act
        List<string> actual = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
        Assert.AreEqual(1, actual.Count);
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "https://abv.bg, http://arena.bg, https://zamunda.net";
        List<string> expected = new List<string>() { "https://abv.bg", "http://arena.bg", "https://zamunda.net" };

        // Act
        List<string> actual = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
        Assert.AreEqual(3, actual.Count);
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "\"https://abv.bg\", \"http://arena.bg\", \"https://zamunda.net\"";
        List<string> expected = new List<string>() { "https://abv.bg", "http://arena.bg", "https://zamunda.net" };

        // Act
        List<string> actual = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
        Assert.AreEqual(3, actual.Count);
    }
}
