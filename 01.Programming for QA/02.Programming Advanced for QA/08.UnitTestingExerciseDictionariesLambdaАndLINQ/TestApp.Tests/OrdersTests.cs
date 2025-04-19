using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] orders = Array.Empty<string>();

        // Act
        string result = Orders.Order(orders);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] orders = new[] { "apple 2.30 2", "banana 3.30 4", "apple 2.60 2", "Orange 1.80 3" };
        string expected = $"apple -> 10.40{Environment.NewLine}banana -> 13.20{Environment.NewLine}Orange -> 5.40";

        // Act
        string result = Orders.Order(orders);

        // Assert
        Assert.AreEqual (expected, result);
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] orders = new[] { "apple 2.00 2", "banana 4.00 4", "apple 3.00 4" };
        string expected = $"apple -> 18.00{Environment.NewLine}banana -> 16.00";

        // Act
        string result = Orders.Order(orders);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] orders = new[] { "apple 2 2.50", "banana 4 4.30", "apple 3 2.40" };
        string expected = $"apple -> 14.70{Environment.NewLine}banana -> 17.20";

        // Act
        string result = Orders.Order(orders);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
