using NUnit.Framework;

namespace TestApp.UnitTests;

public class GradesTests
{
    [TestCase(2.00, "Fail")]
    [TestCase(2.99, "Fail")]
    [TestCase(3.00, "Average")]
    [TestCase(3.49, "Average")]
    [TestCase(3.50, "Good")]
    [TestCase(3.99, "Good")]
    [TestCase(4.00, "Very Good")]    
    [TestCase(4.49, "Very Good")]
    [TestCase(4.50, "Excellent")]
    [TestCase(5.00, "Excellent")]   
    [TestCase(1.99, "Invalid!")]
    [TestCase(5.10, "Invalid!")]
    [TestCase(-2.00, "Invalid!")]
    [TestCase(0.00, "Invalid!")]
    [TestCase(100.00, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString(double grade, string expected)
    {
        // Arrange


        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }
    [TestCase(2.10, "Fail")]
    [TestCase(2.90, "Fail")]
    [TestCase(3.30, "Average")]
    [TestCase(3.39, "Average")]  
    [TestCase(4.30, "Very Good")]
    [TestCase(4.60, "Excellent")]
    [TestCase(5.45, "Invalid!")]
    [TestCase(5.99, "Invalid!")]
    [TestCase(6.10, "Invalid!")]
    [TestCase(1.00, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString_EdgeCases(double grade, string expected)
    {
        // Arrange

        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
