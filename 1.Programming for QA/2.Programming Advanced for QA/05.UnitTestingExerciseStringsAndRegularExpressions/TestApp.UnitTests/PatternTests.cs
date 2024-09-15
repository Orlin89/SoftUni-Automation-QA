using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish the test cases
    [TestCase("Orlin", 2, "oRlInoRlIn")]
    [TestCase("VlaDiMirov", 3, "vLaDiMiRoVvLaDiMiRoVvLaDiMiRoV")]
    [TestCase("Hi", 1, "hI")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, 
        int repetitionFactor, string expected)
    {
        // Arrange

        // Act
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(string.Empty, 2));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("orlin", -3));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        

        // Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("orlin", 0));
    }
}
