using NUnit.Framework;

namespace TestApp.UnitTests;

public class CalculateTests
{
    [TestCase(3, 3 , 6)]
    [TestCase(4, 4, 8)]
    [TestCase(12, 8, 20)]
    public void Test_Addition(int a , int b , int expected)
    {
        // Arrange
        Calculate calculator = new Calculate();

        // Act
        int actual = calculator.Addition(5, 2);

        // Assert
        Assert.AreEqual(7, actual, "Addition did not work properly.");
    }

    [Test]
    public void Test_Subtraction()
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Subtraction(5, 2);

        // Assert
        Assert.AreEqual(3, actual, "Subtraction did not work properly.");

    }
}
