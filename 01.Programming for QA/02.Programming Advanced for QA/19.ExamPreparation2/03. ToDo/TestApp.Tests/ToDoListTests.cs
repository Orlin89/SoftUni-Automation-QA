using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string taskTitle = "firstTask";
        DateTime dateTime = DateTime.Now;
        string expected = $"To-Do List:{Environment.NewLine}" +
            $"[ ] firstTask - Due: 08/14/2024";

        // Act
        _toDoList.AddTask(taskTitle, dateTime);
        string actual = _toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string taskTitle = "firstTask";
        DateTime dateTime = DateTime.Now;
        string expected = $"To-Do List:{Environment.NewLine}" +
            $"[✓] firstTask - Due: 08/14/2024";

        // Act
        _toDoList.AddTask(taskTitle, dateTime);
        _toDoList.CompleteTask(taskTitle);
        string actual = _toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string taskTitle = "firstTask";
        DateTime dateTime = DateTime.Now;       

        // Act
        _toDoList.AddTask(taskTitle, dateTime);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _toDoList.CompleteTask("secondTask"));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        
        string expected = "To-Do List:";

        // Act       
        string actual = _toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string taskTitle = "firstTask";
        string taskTitle2 = "secondTask";
        DateTime dateTime = DateTime.Now;
        DateTime dateTime2 = DateTime.Now;
        string expected = $"To-Do List:{Environment.NewLine}" +
            $"[✓] firstTask - Due: 08/14/2024{Environment.NewLine}" +
            $"[ ] secondTask - Due: 08/14/2024";

        // Act
        _toDoList.AddTask(taskTitle, dateTime);
        _toDoList.AddTask(taskTitle2, dateTime2);
        _toDoList.CompleteTask(taskTitle);
        string actual = _toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
