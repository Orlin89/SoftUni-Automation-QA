using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        // Arrange
        long n = 7;
        long expected = 7;

        // Act
        long actual = PrimeFactor.FindLargestPrimeFactor(n);

        // Assert
        Assert.AreEqual(expected, actual);


    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        // Arrange
        long n = 100;
        long expected = 5;

        // Act
        long actual = PrimeFactor.FindLargestPrimeFactor(n);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
