using NUnit.Framework;
using System;
using System.Diagnostics;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string name = "apple";
        double price = 3;
        int quantity = 1;
        string expected = $"Product Inventory:{Environment.NewLine}apple - Price: $3.00 - Quantity: 1";

        _inventory.AddProduct(name,price,quantity);

        // Act
        string actual = _inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expected, actual);       
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
     
        string expected = "Product Inventory:";

        // Act
        string actual = _inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        string name = "apple";
        double price = 3;
        int quantity = 1;
        string expected = $"Product Inventory:{Environment.NewLine}apple - Price: $3.00 - Quantity: 1";

        _inventory.AddProduct(name, price, quantity);

        // Act
        string actual = _inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange
        double expected = 0;
        
        // Act
        double actual = _inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange

        _inventory.AddProduct("apple", 3, 1);
        _inventory.AddProduct("banana", 3, 1);
        double expected = 6;

        // Act
        double actual = _inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
