using NUnit.Framework;

namespace TestApp.Tests
{
    public class PerfectSquareIntegersTests
    {
        [Test]
        public void Test_FindPerfectSquares_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
        {
            // Arrange
            int startNum = 10;
            int endNum = 1;
            string expected = "Start number should be less than end number.";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNum, endNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_GetSameSquareIntegerForStartAndEnd_ReturnsSameSquareInteger()
        {
            // Arrange
            int startNum = 1;
            int endNum = 1;
            string expected = "1";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNum, endNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_GetZeroAsSingleInteger_ReturnsZero()
        {
            // Arrange
            int startNum = 0;
            int endNum = 0;
            string expected = "0";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNum, endNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_RangeIncludesMultiplePerfectSquares_RetursOnlySquareIntegers()
        {
            // Arrange
            int startNum = 1;
            int endNum = 50;
            string expected = "1 4 9 16 25 36 49";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNum, endNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_NoPerfectSquaresInRange_ReturnsEmptyString()
        {
            // Arrange
            int startNum = 2;
            int endNum = 3;
            string expected = string.Empty;

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNum, endNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

