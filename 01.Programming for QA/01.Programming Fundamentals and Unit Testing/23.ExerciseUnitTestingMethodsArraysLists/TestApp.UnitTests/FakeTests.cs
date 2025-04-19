using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[] chars = { '0', '1', 'a', 'y' };
        char[] expected = { 'a', 'y' };

        // Act
        char[] actual = Fake.RemoveStringNumbers(chars);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        // Arrange
        char[] chars = { 'o', 'u', 'z', 'a', 'y' };
        char[] expected = { 'o', 'u', 'z', 'a', 'y' };

        // Act
        char[] actual = Fake.RemoveStringNumbers(chars);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }


    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        char[] chars = Array.Empty<char>();
        char[] expected = Array.Empty<char>();

        // Act
        char[] actual = Fake.RemoveStringNumbers(chars);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
