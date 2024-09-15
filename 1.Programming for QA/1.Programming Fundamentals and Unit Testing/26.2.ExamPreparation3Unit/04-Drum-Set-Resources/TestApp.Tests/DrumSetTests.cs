using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class DrumSetTests
    {
        [Test]
        public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
        {
            // Arrange
            
            List<int> initialQuality = new List<int> { 10, 15, 20 };
            List<string> commands = new List<string> { "10", "15" }; 

            // Act & Assert
            Assert.Throws<ArgumentException>(() => DrumSet.Drum(100, initialQuality, commands));
        }

        [Test]
        public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
        {
            // Arrange
            
            List<int> initialQuality = new List<int> { 10, 15, 20 };
            List<string> commands = new List<string> { "10","Hello" }; 

            // Act & Assert
            Assert.Throws<ArgumentException>(() => DrumSet.Drum(100, initialQuality, commands));
        }

        [Test]
        public void Test_Drum_ReturnsCorrectQualityAndAmount()
        {
            // Arrange
             
            List<int> initialQuality = new List<int> { 10, 15, 20 };
            List<string> commands = new List<string> { "10", "Hit it again, Gabsy!" };

            // Act
            string result = DrumSet.Drum(100, initialQuality, commands);

            // Assert
            string expected = "10 5 10\nGabsy has 70.00lv.";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount()
        {
            // Arrange
            
            List<int> initialQuality = new List<int> { 10, 15, 20 };
            List<string> commands = new List<string> { "10", "Hit it again, Gabsy!" };

            // Act
            string result = DrumSet.Drum(0, initialQuality, commands);

            // Assert
            string expected = "5 10\nGabsy has 0.00lv."; 
        }

        [Test]
        public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount()
        {
            // Arrange
            
            List<int> initialQuality = new List<int> { 10, 15, 20 };
            List<string> commands = new List<string> { "10", "Hit it again, Gabsy!" };

            // Act
            string result = DrumSet.Drum(5, initialQuality, commands);

            // Assert
            string expected = "5 10\nGabsy has 5.00lv.";
            Assert.AreEqual(expected, result);
        }
    }
}
