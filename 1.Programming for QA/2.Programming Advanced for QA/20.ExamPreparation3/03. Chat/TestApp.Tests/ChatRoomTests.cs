using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;

    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }

    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        string sender = "Orlin";
        string message = "hello world";
        string expectedDate = DateTime.Now.Date.ToString("d");
        string expected = $"Chat Room Messages:{Environment.NewLine}" +
                          $"Orlin: hello world - Sent at {expectedDate}";

        // Act
        _chatRoom.SendMessage(sender, message);
        string actual = _chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange       
        string expected = string.Empty;

        // Act       
        string actual = _chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string sender = "Orlin";
        string message = "hello world";
        string expectedDate = DateTime.Now.Date.ToString("d");
        string expected = $"Chat Room Messages:{Environment.NewLine}" +
                          $"Orlin: hello world - Sent at {expectedDate}";

        // Act
        _chatRoom.SendMessage(sender, message);
        string actual = _chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
