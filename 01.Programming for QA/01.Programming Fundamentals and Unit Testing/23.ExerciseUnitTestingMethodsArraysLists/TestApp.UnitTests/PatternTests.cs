using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] numbers = new int[] { 2, 2, 4, 30, 40, 12, 5, 6, 10 };
        int[] expected = new int[] { 2, 40, 4, 30, 5, 12, 6, 10 };

        // Act 
        int[] actual = Pattern.SortInPattern(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);

    }
        [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        int[] expected = Array.Empty<int>();

        // Act 
        int[] actual = Pattern.SortInPattern(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        int[] numbers = new int[] { 23 };
        int[] expected = new int[] { 23 };

        // Act 
        int[] actual = Pattern.SortInPattern(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
