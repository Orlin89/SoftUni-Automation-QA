using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PalindromeTests
{
    // TODO: finish test
    [Test]
    public void Test_IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "Orlin nilrO", "Hello olleH" };

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(actual);
    }

    // TODO: finish test
    [Test]
    public void Test_IsPalindrome_EmptyList_ReturnsTrue()
    {
        // Arrange
        List<string> input = new();

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(actual);
    }

    [Test]
    public void Test_IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "Orange egnarO" };

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(actual);
    }

    [Test]
    public void Test_IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        // Arrange
        List<string> input = new List<string>() { "Apple End" };

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsFalse(actual);
    }

    [Test]
    public void Test_IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "Gosho ohsoG", "Pesho ohseP", "Ivan navI" };

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(actual);
    }
}
