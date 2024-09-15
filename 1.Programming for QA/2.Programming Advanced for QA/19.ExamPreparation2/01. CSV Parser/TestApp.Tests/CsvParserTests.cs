using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string input = string.Empty;
        string[] expected = Array.Empty<string>();

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string input = "a";
        string[] expected = new string[]{"a"};

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string input = "a,b,c";
        string[] expected = new string[] { "a", "b", "c" };

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        string input = "  a  ,  b  ,  c  ";
        string[] expected = new string[] { "a", "b", "c" };

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
