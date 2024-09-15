using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] strings = null;

        // Act
        

        // Assert
        Assert.Throws<ArgumentNullException>(() => LongestIncreasingSubsequence.GetLis(strings));
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        // Arrange
        int[] strings = new int [0];
        string expected = "";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(strings);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));  
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        int[] strings = new int[] { 1 };
        string expected = "1";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(strings);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        int[] strings = new int[] { 1, 25, 10, 30, 4, 45 };
        string expected = "1 25 30 45";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(strings);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        int[] strings = new int[] { 23, 36, 38, 52, 567 };
        string expected = "23 36 38 52 567";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(strings);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
