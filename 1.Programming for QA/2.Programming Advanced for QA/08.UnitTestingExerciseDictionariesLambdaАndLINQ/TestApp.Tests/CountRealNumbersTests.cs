using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] nums = Array.Empty<int>();
        string expected = string.Empty;

        // Act
        string actual = CountRealNumbers.Count(nums);

        // Assert
        Assert.That(actual, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { 1 };
        string expected = $"1 -> 1";

        // Act
        string actual = CountRealNumbers.Count(nums);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { 1, 3, 5, 3, 1 };
        string expected = $"1 -> 2{Environment.NewLine}3 -> 2{Environment.NewLine}5 -> 1";

        // Act
        string actual = CountRealNumbers.Count(nums);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { -1, -3, -5, -3, -1 };
        string expected = $"-5 -> 1{Environment.NewLine}-3 -> 2{Environment.NewLine}-1 -> 2";

        // Act
        string actual = CountRealNumbers.Count(nums);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] nums = new int[] { -1, -3, -5, 0, -3, -1 };
        string expected = $"-5 -> 1{Environment.NewLine}-3 -> 2{Environment.NewLine}-1 -> 2{Environment.NewLine}0 -> 1";

        // Act
        string actual = CountRealNumbers.Count(nums);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
