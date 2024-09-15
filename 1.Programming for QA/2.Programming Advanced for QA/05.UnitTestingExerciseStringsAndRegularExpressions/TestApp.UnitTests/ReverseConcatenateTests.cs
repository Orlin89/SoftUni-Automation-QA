using NUnit.Framework;

using System;
using System.Linq;

namespace TestApp.UnitTests;

public class ReverseConcatenateTests
{
    // TODO: finish the test
    [Test]
    public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] text = Array.Empty<string>();
        string actual = string.Empty;
        
        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(text);

        // Assert
        Assert.AreEqual(actual, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
    {
        // Arrange
        string[] text = new string[] { "hello"};
        string actual = "hello";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(text);

        // Assert
        Assert.AreEqual(actual, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] text = new string[] { "Vladimirov", "Orlin", "hello" };
        string actual = "helloOrlinVladimirov";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(text);

        // Assert
        Assert.AreEqual(actual, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string[] text = null;
        string actual = string.Empty;

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(text);

        // Assert
        Assert.AreEqual(actual, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
    {
        // Arrange
        string[] text = new string[] { " " };
        string actual = " ";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(text);

        // Assert
        Assert.AreEqual(actual, result);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
    {
        //Arrange
        string[] input = new string[10000];
        for (int i = 0; i < 10000; i++)
        {
            input[i] = i.ToString();
        }
        string expected = string.Join("", input.Reverse());

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
