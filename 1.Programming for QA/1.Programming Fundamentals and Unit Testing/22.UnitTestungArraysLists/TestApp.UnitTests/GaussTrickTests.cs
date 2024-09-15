using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        List<int> result = GaussTrick.SumPairs(emptyList);

        // Assert
        CollectionAssert.AreEqual(emptyList, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 5 };


        // Act
        List<int> result = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(numbers, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 4, 6, 10 };
        List<int> expected = new List<int>() { 12, 10 };

        // Act
        List<int> result = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 4, 9, 6, 10 };
        List<int> expected = new List<int>() { 12, 10, 9 };

        // Act
        List<int> result = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 3, 6, 10, 14, 5 };
        List<int> expected = new List<int>() { 7, 17, 16 };

        // Act
        List<int> result = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 3, 6, 8, 10, 14, 5 };
        List<int> expected = new List<int>() { 7, 17, 16, 8 };

        // Act
        List<int> result = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
