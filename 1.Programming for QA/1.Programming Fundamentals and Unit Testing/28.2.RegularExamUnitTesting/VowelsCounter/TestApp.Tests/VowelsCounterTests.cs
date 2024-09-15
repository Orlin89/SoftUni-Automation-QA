using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class VowelsCounterTests
    {
        [Test]
        public void Test_CountTotalVowels_GetEmptyList_ReturnsZero()
        {
            // Arrange
            List<string> list = new List<string>();
            int expected = 0;

            // Act
            int actual = VowelsCounter.CountTotalVowels(list);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_GetListWithEmptyStringValues_ReturnsZero()
        {
            // Arrange
            List<string> list = new List<string>() { string.Empty};
            int expected = 0;

            // Act
            int actual = VowelsCounter.CountTotalVowels(list);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_MultipleLowerCaseStrings_ReturnsVowelsCount()
        {
            // Arrange
            List<string> list = new List<string>() {"aoert", "qwre", "dfu"};
            int expected = 5;

            // Act
            int actual = VowelsCounter.CountTotalVowels(list);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_GetStringsWithNoVowels_ReturnsZero()
        {
            // Arrange
            List<string> list = new List<string>() {"gtfd", "qzxs", "hjk" };
            int expected = 0;

            // Act
            int actual = VowelsCounter.CountTotalVowels(list);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_StringsWithMixedCaseVowels_ReturnsVowelsCount()
        {
            // Arrange
            List<string> list = new List<string>() { "hI", "hallO", "orlin" };
            int expected = 5;

            // Act
            int actual = VowelsCounter.CountTotalVowels(list);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

