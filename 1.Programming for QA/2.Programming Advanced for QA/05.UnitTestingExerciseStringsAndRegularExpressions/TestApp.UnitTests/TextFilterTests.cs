using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] banned = new string[] { "friday"};
        string text = "Today is a good day";
        string expected = "Today is a good day";
        // Act
        string actual = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] banned = new string[] { "good" };
        string text = "Today is a good day";
        string expected = "Today is a **** day";
        // Act
        string actual = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] banned = Array.Empty<string>();
        string text = "Today is a good day";
        string expected = "Today is a good day";
        // Act
        string actual = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] banned = new string[] { " " };
        string text = "Today is a good day";
        string expected = "Today*is*a*good*day";
        // Act
        string actual = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
