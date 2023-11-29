using System;
using TaskManager.models;

namespace TaskManagerTests.testModels;

public class UTaskTests
{
    public void TestUTaskConstructor_ValidParameters()
    {
        var dueDate = DateTime.Now.AddDays(2); //  over 1 for future should pass, less then 1 should fail
        var task = new UTask("Test Task", "This is a test note.", dueDate);

        Console.WriteLine(task.Title == "Test Task" ? "Title Test Pass" : "Title Test Fail");
        Console.WriteLine(task.Note == "This is a test note." ? "Note Test Pass" : "Note Test Fail");
        Console.WriteLine(task.DueDate == dueDate ? "Due Date Test Pass" : "Due Date Test Fail");
    }

    public void TestUTaskConstructor_InvalidParameters()
    {
        try
        {
            var task = new UTask("", null, DateTime.Now.AddDays(-1));
            Console.WriteLine("Constructor Invalid Parameters Test Fail");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Constructor Invalid Parameters Test Pass");
        }
    }

    public void TestUpdateTitle()
    {
        var task = new UTask("Initial Title", "Note", DateTime.Now.AddDays(1));

        // Test with valid input
        try
        {
            task.UpdateTitle("New Valid Title");
            Console.WriteLine(task.Title == "New Valid Title" ? "Update Title Valid Test Pass" : "Update Title Valid Test Fail");
        }
        catch (Exception)
        {
            Console.WriteLine("Update Title Valid Test Fail");
        }

        // Test with invalid input
        try
        {
            task.UpdateTitle("");
            Console.WriteLine("Update Title Invalid Test Fail");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Update Title Invalid Test Pass");
        }
    }
    
    public void TestUpdateNote()
{
    var task = new UTask("Title", "Initial Note", DateTime.Now.AddDays(1));

    // Test with valid note
    task.UpdateNote("New Note");
    Console.WriteLine(task.Note == "New Note" ? "Update Note Valid Test Pass" : "Update Note Valid Test Fail");

    // Test with null input
    task.UpdateNote(null);
    Console.WriteLine(string.IsNullOrEmpty(task.Note) ? "Update Note Null Test Pass" : "Update Note Null Test Fail");
}

    public void TestUpdateDueDate()
    {
        var task = new UTask("Title", "Note", DateTime.Now.AddDays(10));

        // Test with valid future date
        var newValidDate = DateTime.Now.AddDays(15);
        try
        {
            task.UpdateDueDate(newValidDate);
            Console.WriteLine(task.DueDate == newValidDate ? "Update Due Date Valid Test Pass" : "Update Due Date Valid Test Fail");
        }
        catch (Exception)
        {
            Console.WriteLine("Update Due Date Valid Test Fail");
        }

        // Test with invalid past date
        var newInvalidDate = DateTime.Now.AddDays(-5);
        try
        {
            task.UpdateDueDate(newInvalidDate);
            Console.WriteLine("Update Due Date Invalid Test Fail");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Update Due Date Invalid Test Pass");
        }
    }
//passed
}

