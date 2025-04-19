using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        string actual = CenterPoint.GetClosest(1, 1, 2, 2);
        string expected = "(1, 1)";
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        string actual = CenterPoint.GetClosest(2, 2, 1, 1);
        string expected = "(1, 1)";
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        string actual = CenterPoint.GetClosest(2, 2, 2, 2);
        string expected = "(2, 2)";
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        string actual = CenterPoint.GetClosest(-2, -2, 2, 2);
        string expected = "(-2, -2)";
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        string actual = CenterPoint.GetClosest(2, 2, -2, -2);
        string expected = "(-2, -2)";
        Assert.AreEqual(expected, actual);
    }
}
