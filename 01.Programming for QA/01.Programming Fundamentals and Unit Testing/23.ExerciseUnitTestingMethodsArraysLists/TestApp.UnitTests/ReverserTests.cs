using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] inputArray = Array.Empty<string>();

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange
        string[] array = new string[] {"Hello"};
        string[] expected = new string[] {"olleH"};

        // Act
        string[] actual = Reverser.ReverseStrings(array);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange
        string[] array = new string[] { "Hello", "Orlin" };
        string[] expected = new string[] { "olleH", "nilrO" };

        // Act
        string[] actual = Reverser.ReverseStrings(array);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange
        string[] array = new string[] { "Hello!", "@Orlin"  };
        string[] expected = new string[] { "!olleH", "nilrO@" };

        // Act
        string[] actual = Reverser.ReverseStrings(array);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
