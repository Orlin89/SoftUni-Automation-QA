using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{

    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        // Assert
        List<int> numbers = new List<int>() { 5 };
        int expected = 5;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        // Assert
        List<int> numbers = new List<int>() { 5, 47, 2, 1 };
        int expected = 47;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        // Assert
        List<int> numbers = new List<int>() { -23, -37, -400, -1, -40 };
        int expected = -1;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        // Assert
        List<int> numbers = new List<int>() { 5, 64, 0, -2, 1, -20 };
        int expected = 64;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        // Assert
        List<int> numbers = new List<int>() { 5, 600, 0, -2, 600, 1, -20 };
        int expected = 600;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
