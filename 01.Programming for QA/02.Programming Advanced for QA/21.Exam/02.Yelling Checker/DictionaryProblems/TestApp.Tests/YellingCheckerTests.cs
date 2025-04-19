using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class YellingCheckerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = string.Empty;
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyUpperCaseWords_ReturnsDictionaryWithYellingEntriesOnly()
    {
        // Arrange
        string input = "HELLO ORLIN";
        Dictionary<string, int> expected = new Dictionary<string, int>() { { "yelling", 2 } };

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyLowerCaseWords_ReturnsDictionaryWithSpeakingLowerEntriesOnly()
    {
        // Arrange
        string input = "good day";
        Dictionary<string, int> expected = new Dictionary<string, int>() { { "speaking lower", 2 } };

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyMixedCaseWords_ReturnsDictionaryWithASpeakingNormalEntriesOnly()
    {
        // Arrange
        string input = "Hi Orlin";
        Dictionary<string, int> expected = new Dictionary<string, int>() { { "speaking normal", 2 } };

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_LowerUpperMixedCasesWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        string input = "HI THERE are you Ok";
        Dictionary<string, int> expected = new Dictionary<string, int>() { 
            { "yelling", 2 },
            {"speaking lower", 2 },
            { "speaking normal", 1}
        };

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}

