using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class CargoManagementSystemTests
{
    [Test]
    public void Test_Constructor_CheckInitialEmptyCargoCollectionAndCount()
    {
        // Arrange & Act
        CargoManagementSystem _cargo = new CargoManagementSystem();

        // Assert
        Assert.AreEqual(0, _cargo.CargoCount);
        Assert.IsEmpty(_cargo.GetAllCargos());
    }

    [Test]
    public void Test_AddCargo_ValidCargoName_AddNewCargo()
    {
        // Arrange
        string input = "sand";
        CargoManagementSystem _cargo = new CargoManagementSystem();
        List<string> expected = new List<string>() {"sand" };

        // Act
        _cargo.AddCargo(input);
        List<string> actual = _cargo.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        string input = string.Empty;
        CargoManagementSystem _cargo = new CargoManagementSystem();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _cargo.AddCargo(input));
    }

    [Test]
    public void Test_RemoveCargo_ValidCargoName_RemoveFirstCargoName()
    {
        // Arrange       
        CargoManagementSystem _cargo = new CargoManagementSystem();
        List<string> expected = new List<string>() { "concrete" };

        // Act
        _cargo.AddCargo("sand");
        _cargo.AddCargo("concrete");
        _cargo.RemoveCargo("sand");
        List<string> actual = _cargo.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange       
        CargoManagementSystem _cargo = new CargoManagementSystem();
        _cargo.AddCargo("sand");
        _cargo.AddCargo("concrete");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _cargo.RemoveCargo(null));
    }

    [Test]
    public void Test_GetAllCargos_AddedAndRemovedCargos_ReturnsExpectedCargoCollection()
    {
        // Arrange       
        CargoManagementSystem _cargo = new CargoManagementSystem();
        List<string> expected = new List<string>() { "concrete", "banana" };

        // Act
        _cargo.AddCargo("sand");
        _cargo.AddCargo("concrete");
        _cargo.RemoveCargo("sand");
        _cargo.AddCargo("banana");
        List<string> actual = _cargo.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}

    