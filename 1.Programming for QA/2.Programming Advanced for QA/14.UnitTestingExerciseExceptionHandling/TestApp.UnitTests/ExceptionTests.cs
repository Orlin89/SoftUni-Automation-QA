using NUnit.Framework;

using System;
using System.Collections.Generic;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
            string input = "hello";
            string expected = "olleh";

        // Act
        string actual = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _exceptions.ArgumentNullReverse(input));
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = 10;
        decimal expected = 90;

        // Act
        decimal actual = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = -10;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount));
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };
        int index = 2;
        int expected = 3;

        // Act
        int actual = _exceptions.IndexOutOfRangeGetElement(input, index);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };
        int index = -2;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = input.Length;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };
        int index = 10;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool isLoggedIn= true;
        string expected = "User logged in.";

        // Act 
        string actual = _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool isLoggedIn = false;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn));
        
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "5";
        int expected = 5;

        // Act
        int actual = _exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "a";

        // Act & Assert
        Assert.Throws<FormatException>(() => _exceptions.FormatExceptionParseInt(input));
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4
        };
        string key = "two";
        int expected = 2;

        // Act
        int actual = _exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.AreEqual(expected, actual);       
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4
        };
        string key = "five";

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => _exceptions.KeyNotFoundFindValueByKey(input, key));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 4;
        int b = 5;
        int expected = 9;

        // Act 
        int actual = _exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 5;

        // Act & Assert
        Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b));
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -2;

        // Act & Assert
        Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b));
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int divident = 10;
        int divisor = 2;
        int expected = 5;

        // Act 
        int actual = _exceptions.DivideByZeroDivideNumbers(divident, divisor);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int divident = 10;
        int divisor = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _exceptions.DivideByZeroDivideNumbers(divident, divisor));
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] input = { 1, 2, 3 };
        int index = 1;
        int expected = 6;

        // Act 
        int actual = _exceptions.SumCollectionElements(input, index);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] input = null;
        int index = 1;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _exceptions.SumCollectionElements(input, index));
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 1, 2, 3 };
        int index = 3;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.SumCollectionElements(input, index));
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3"
        };
        string key = "one";
        int expected = 1;

        // Act 
        int actual = _exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3"
        };
        string key = "four";

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => _exceptions.GetElementAsNumber(input, key));
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "a",
            ["two"] = "b",
            ["three"] = "c"
        };
        string key = "two";

        // Act & Assert
        Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(input, key));
    }
}
