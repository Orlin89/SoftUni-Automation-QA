using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> nums = new List<int>();

        // Act
        string actual = Grouping.GroupNumbers(nums);

        // Assert
        Assert.That(actual, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int>() { 1, 2, 3, 10};
        string expected = $"Odd numbers: 1, 3{Environment.NewLine}Even numbers: 2, 10";

        // Act
        string actual = Grouping.GroupNumbers(nums);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int>() { 2, 4, 6 };
        string expected = $"Even numbers: 2, 4, 6";

        // Act
        string actual = Grouping.GroupNumbers(nums);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int>() { 1, 3, 5 };
        string expected = $"Odd numbers: 1, 3, 5";

        // Act
        string actual = Grouping.GroupNumbers(nums);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> nums = new List<int>() { -1, -3, -9 };
        string expected = $"Odd numbers: -1, -3, -9";

        // Act
        string actual = Grouping.GroupNumbers(nums);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
