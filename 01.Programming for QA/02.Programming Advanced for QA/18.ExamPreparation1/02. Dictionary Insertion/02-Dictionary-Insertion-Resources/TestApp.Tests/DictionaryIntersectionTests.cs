using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>() { ["Orlin"] = 35 };
        Dictionary<string, int> dict2 = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>() { ["Orlin"] = 35 };
        Dictionary<string, int> dict2 = new Dictionary<string, int>() { ["Joro"] = 35 };
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>() { ["Orlin"] = 35 };
        Dictionary<string, int> dict2 = new Dictionary<string, int>() { ["Orlin"] = 35 };
        Dictionary<string, int> expected = new Dictionary<string, int>() { ["Orlin"] = 35 };

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>() { ["Orlin"] = 35 };
        Dictionary<string, int> dict2 = new Dictionary<string, int>() { ["Orlin"] = 30 };
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
