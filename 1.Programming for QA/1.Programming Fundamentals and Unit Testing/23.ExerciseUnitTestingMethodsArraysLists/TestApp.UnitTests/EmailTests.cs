using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailTests
{
    // TODO: finish test
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act
        bool actual = Email.IsValidEmail(validEmail);

        // Assert
        Assert.That(actual, Is.True);

    }

    [Test]
    public void Test_IsValidEmail_InvalidEmail()
    {
        // Arrange
        string email = "@abv.bg";

        // Act
        bool actual = Email.IsValidEmail(email);

        // Assert
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Test_IsValidEmail_NullInput()
    {
        // Assert
        string email = null;

        // Act
        bool actual = Email.IsValidEmail(email);

        // Assert
        Assert.IsFalse(actual);
    }
}
