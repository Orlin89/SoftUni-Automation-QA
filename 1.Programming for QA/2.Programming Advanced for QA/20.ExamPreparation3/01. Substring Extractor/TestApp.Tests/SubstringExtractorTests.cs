using NUnit.Framework;
using System.Net.Security;

namespace TestApp.Tests;

[TestFixture]
public class SubstringExtractorTests
{
    [Test]
    public void Test_ExtractSubstringBetweenMarkers_SubstringFound_ReturnsExtractedSubstring()
    {
        // Arrange
        string input = "hello world";
        string startMarker = "l";
        string endMarker = "rl";
        string expected = "lo wo";

        // Act 
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartMarkerNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "hello world";
        string startMarker = "q";
        string endMarker = "rld";
        string expected = "Substring not found";

        // Act 
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EndMarkerNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "hello world";
        string startMarker = "e";
        string endMarker = "g";
        string expected = "Substring not found";

        // Act 
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "hello world";
        string startMarker = "t";
        string endMarker = "j";
        string expected = "Substring not found";

        // Act 
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EmptyInput_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = string.Empty;
        string startMarker = "l";
        string endMarker = "rl";
        string expected = "Substring not found";

        // Act 
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersOverlapping_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "hello world";
        string startMarker = "r";
        string endMarker = "h";
        string expected = "Substring not found";

        // Act 
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
