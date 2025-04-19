using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    // TODO: finish test
    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(emptyList, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange
        List<int> emptyList = new() { 1, 2, 3, 4, 5 };
        string expected = "1 2 3 4 5";

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        // Arrange
        List<int> emptyList = new() { 1, 2, 2, 3, 4, 5 };
        string expected = "1 4 3 4 5";

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        // Arrange
        List<int> emptyList = new() { 2, 2 };
        string expected = "4";

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        // Arrange
        List<int> emptyList = new() { 3, 3, 8, 4, 9 };
        string expected = "6 8 4 9";

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        // Arrange
        List<int> emptyList = new() { 60, 2, 34, 4, 5, 5 };
        string expected = "60 2 34 4 10";

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersInMiddle_ShouldReturnSummedList()
    {
        // Arrange
        List<int> emptyList = new() { 22, 38, 1, 1, 50, 6 };
        string expected = "22 38 2 50 6";

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
