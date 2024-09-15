using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    // TODO: finish the test
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string toRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown jumps over the lazy dog";

        // Act
        string actual = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string toRemove = "The";
        string input = "The quick brown fox jumps over lazy dog";
        string expected = "quick brown fox jumps over lazy dog";

        // Act
        string actual = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string toRemove = "dog";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown fox jumps over the lazy";

        // Act
        string actual = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string toRemove = "dog";
        string input = "The quick brown dog jumps over the lazy dog";
        string expected = "The quick brown jumps over the lazy";

        // Act
        string actual = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
