using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, "5 5 13 13")]
    [TestCase(new int[] { 8, 7, 6, 5, 4, 3, 2, 1 }, "13 13 5 5")]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, "2 2 2 2")]
    [TestCase(new int[] { 1, 2, 3, 4, 1, 2, 3, 4 }, "5 5 5 5")]
    [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70, 80 }, "50 50 130 130")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        string result = FoldSum.FoldArray(arr);
        Assert.AreEqual(expected, result);
    }
}
