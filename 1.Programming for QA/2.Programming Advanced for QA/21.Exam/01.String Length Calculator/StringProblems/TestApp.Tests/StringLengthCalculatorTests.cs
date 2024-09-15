using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class StringLengthCalculatorTests
{
    [Test]
    public void Test_Calculate_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = string.Empty;
        int expected = 0;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Calculate_SingleEvenLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "good";
        int expected = 850;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_Calculate_SingleOddLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "Orlin";
        int expected = 258;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Calculate_WholeSentenceString_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "Today is very good day.";
        int expected = 1052;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

}

