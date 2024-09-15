using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        int positions = 2;
        string expected = string.Empty;

        // Act
        string actual = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // Arrange
        string input = "hello";
        int positions = 0;
        string expected = "hello";

        // Act
        string actual = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "hello";
        int positions = 2;
        string expected = "lohel";

        // Act
        string actual = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "hello";
        int positions = -2;
        string expected = "lohel";

        // Act
        string actual = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        // Arrange
        string input = "hello";
        int positions = 7;
        string expected = "lohel";

        // Act
        string actual = StringRotator.RotateRight(input, positions);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
