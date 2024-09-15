using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>() 
        { 
            {"Orlin", 6 },
            {"Miro", 3 },
            {"Joro", 4},
            {"Gosho", 5 }
        };
        string expected = $"Orlin with average grade 6.00{Environment.NewLine}" +
                          $"Gosho with average grade 5.00{Environment.NewLine}" +
                          $"Joro with average grade 4.00";

        // Act
        string actual = Grades.GetBestStudents(grades);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>();
       
        string expected = string.Empty ;

        // Act
        string actual = Grades.GetBestStudents(grades);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            {"Orlin", 6 },           
            {"Joro", 4}
            
        };
        string expected = $"Orlin with average grade 6.00{Environment.NewLine}" +           
                          $"Joro with average grade 4.00";

        // Act
        string actual = Grades.GetBestStudents(grades);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            {"Orlin", 6 },
            {"Miro", 3 },
            {"Joro", 6},
            {"Gosho", 6 }
        };
        string expected = $"Gosho with average grade 6.00{Environment.NewLine}" +
                          $"Joro with average grade 6.00{Environment.NewLine}" +
                          $"Orlin with average grade 6.00";
                     
        // Act
        string actual = Grades.GetBestStudents(grades);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
