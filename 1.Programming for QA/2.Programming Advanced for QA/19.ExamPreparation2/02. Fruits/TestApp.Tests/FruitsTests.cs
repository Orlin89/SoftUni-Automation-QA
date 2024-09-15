using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        string name = "apple";
        Dictionary<string, int> data = new Dictionary<string, int> { { "apple", 2 } };
        int expected = 2;

        // Act
        int actual = Fruits.GetFruitQuantity(data, name);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        string name = "banana";
        Dictionary<string, int> data = new Dictionary<string, int> { { "apple", 2 } };
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(data, name);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        string name = "apple";
        Dictionary<string, int> data = new Dictionary<string, int> {};
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(data, name);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        string name = "apple";
        Dictionary<string, int> data = null;
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(data, name);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        string name = null;
        Dictionary<string, int> data = new Dictionary<string, int> { { "apple", 2 } };
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(data, name);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
