using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = Array.Empty<string>();

        // Act
        string actual = OddOccurrences.FindOdd(words);

        //Assert
        Assert.AreEqual(actual, String.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = new string[] { "apple", "apple"};

        // Act
        string actual = OddOccurrences.FindOdd(words);

        //Assert
        Assert.AreEqual(actual, String.Empty);
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] words = new string[] { "apple" };
        string expected = "apple";

        // Act
        string actual = OddOccurrences.FindOdd(words);

        //Assert
        Assert.AreEqual(actual, expected);
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] words = new string[] { "apple", "orange", "kiwi" };
        string expected = "apple orange kiwi";

        // Act
        string actual = OddOccurrences.FindOdd(words);

        //Assert
        Assert.AreEqual(actual, expected);
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] words = new string[] { "applE", "Orange", "kIwi" };
        string expected = "apple orange kiwi";

        // Act
        string actual = OddOccurrences.FindOdd(words);

        //Assert
        Assert.AreEqual(actual, expected);
    }
}
