using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(input));
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        // Arrange
        string input = string.Empty;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(input));
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        // Arrange
        string input = "C:\\Users\\John\\Documents\\example.txt";
        string expected = "File name: example\nFile extension: txt";

        // Act
        string actual = ExtractFile.GetFile(input);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        // Arrange
        string input = "C:\\Users\\John\\Documents\\example";
        string expected = "File name: example";

        // Act
        string actual = ExtractFile.GetFile(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {
        // Arrange
        string input = "C:\\Users\\John\\Documents?\\example.txt";
        string expected = "File name: example\nFile extension: txt";

        // Act
        string actual = ExtractFile.GetFile(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
