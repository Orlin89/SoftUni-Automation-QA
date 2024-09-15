using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] miners = Array.Empty<string>();

        // Act
        string result = Miner.Mine(miners);

        // Assert
        Assert.AreEqual(result, string.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] miners = new string[] { "Gold 8", "silveR 30" };

        // Act
        string result = Miner.Mine(miners);

        // Assert
        Assert.That(result, Is.EqualTo($"gold -> 8{Environment.NewLine}silver -> 30"));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] miners = new string[] { "Gold 8", "silveR 30", "gold 20" };

        // Act
        string result = Miner.Mine(miners);

        // Assert
        Assert.That(result, Is.EqualTo($"gold -> 28{Environment.NewLine}silver -> 30"));
    }
}
