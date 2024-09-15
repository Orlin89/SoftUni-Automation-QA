using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class DuplicatesTests
{
    // TODO: finish test
    [Test]
    public void Test_RemoveDuplicates_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        int[] expected = Array.Empty<int>();

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_RemoveDuplicates_NoDuplicates_ReturnsOriginalArray()
    {
        // Arrange
        int[] numbers = new int[]{ 2, 4, 7, 5};
        int[] expected = new int[] { 2, 4, 7, 5 };

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveDuplicates_SomeDuplicates_ReturnsUniqueArray()
    {
        // Arrange
        int[] numbers = new int[] { 3, 3, 20, 17, 8, 8 };
        int[] expected = new int[] { 3, 20, 17, 8 };

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveDuplicates_AllDuplicates_ReturnsSingleElementArray()
    {
        // Arrange
        int[] numbers = new int[] { 2, 2};
        int[] expected = new int[] { 2,};

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
