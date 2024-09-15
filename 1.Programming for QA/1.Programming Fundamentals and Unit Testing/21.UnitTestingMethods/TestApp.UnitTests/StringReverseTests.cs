using NUnit.Framework;

namespace TestApp.UnitTests;

public class StringReverseTests
{
    // TODO: finish test
    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = string.Empty;

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(expected, actual);                                                  
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        // Arrange
        string input = "a";
        string expected = "a";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual (expected, actual);
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        // Arrange
        string input = "abc";
        string expected = "cba";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
