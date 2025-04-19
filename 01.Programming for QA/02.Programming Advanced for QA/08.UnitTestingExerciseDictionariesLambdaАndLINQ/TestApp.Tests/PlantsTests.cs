using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = Array.Empty<string>();

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.AreEqual(result, string.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = new[] { "rose" };
        string expected = $"Plants with 4 letters:{Environment.NewLine}rose";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.AreEqual(result, expected);
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = new[] { "rose", "neven", "lily" };
        string expected = $"Plants with 4 letters:" +
            $"{Environment.NewLine}rose" +
            $"{Environment.NewLine}lily" +
            $"{Environment.NewLine}Plants with 5 letters:" +
            $"{Environment.NewLine}neven";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.AreEqual(result, expected);
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] plants = new[] { "Rose", "Neven", "lily" };
        string expected = $"Plants with 4 letters:" +
            $"{Environment.NewLine}Rose" +
            $"{Environment.NewLine}lily" +
            $"{Environment.NewLine}Plants with 5 letters:" +
            $"{Environment.NewLine}Neven";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.AreEqual(result, expected);
    }
}
