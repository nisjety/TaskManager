using TaskManager.utilities;

public class InputValidatorTests
{
    public void TestIsValidUsername()
    {
        Console.WriteLine(InputValidator.IsValidUsername("User123") ? "Username Valid Test Pass" : "Username Valid Test Fail");
        Console.WriteLine(!InputValidator.IsValidUsername("") ? "Username Invalid Test Pass" : "Username Invalid Test Fail");
        // Add more cases as needed...
    }

    public void TestIsValidPassword()
    {
        Console.WriteLine(InputValidator.IsValidPassword("Password123") ? "Password Valid Test Pass" : "Password Valid Test Fail");
        Console.WriteLine(!InputValidator.IsValidPassword("") ? "Password Invalid Test Pass" : "Password Invalid Test Fail");
        // Add more cases as needed...
    }

    public void TestIsValidEmail()
    {
        Console.WriteLine(InputValidator.IsValidEmail("email@example.com") ? "Email Valid Test Pass" : "Email Valid Test Fail");
        Console.WriteLine(!InputValidator.IsValidEmail("notanemail") ? "Email Invalid Test Pass" : "Email Invalid Test Fail");
        // Add more cases as needed...
    }
    
    public void TestIsValidTitle()
    {
        // Test with valid title
        Console.WriteLine(InputValidator.IsValidTitle("ValidTitle") ? "IsValidTitle Valid Test Pass" : "IsValidTitle Valid Test Fail");

        // Test with empty title
        Console.WriteLine(!InputValidator.IsValidTitle("") ? "IsValidTitle Empty Test Pass" : "IsValidTitle Empty Test Fail");

        // Test with too long title
        Console.WriteLine(!InputValidator.IsValidTitle("This title is way too long") ? "IsValidTitle Long Test Pass" : "IsValidTitle Long Test Fail");
    }
    
    public void TestIsValidNote()
    {
        // Test with valid note
        Console.WriteLine(InputValidator.IsValidNote("This is a valid note.") ? "IsValidNote Valid Test Pass" : "IsValidNote Valid Test Fail");

        // Test with null note
        Console.WriteLine(InputValidator.IsValidNote(null) ? "IsValidNote Null Test Pass" : "IsValidNote Null Test Fail");

        // Test with too long note
        string longNote = new string('a', 1001); // 1001 characters
        Console.WriteLine(!InputValidator.IsValidNote(longNote) ? "IsValidNote Long Test Pass" : "IsValidNote Long Test Fail");
    }
    
    public void TestIsValidDate()
    {
        DateTime dueDate;

        // Test with valid future date
        var futureDateStr = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd");
        var futureDate = DateTime.Parse(futureDateStr);
        if (InputValidator.IsValidDate(futureDateStr, out dueDate) && dueDate == futureDate)
        {
            Console.WriteLine("IsValidDate Future Test Pass");
        }
        else
        {
            Console.WriteLine("IsValidDate Future Test Fail");
        }

        // Test with past date
        var pastDateStr = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
        if (!InputValidator.IsValidDate(pastDateStr, out dueDate))
        {
            Console.WriteLine("IsValidDate Past Test Pass");
        }
        else
        {
            Console.WriteLine("IsValidDate Past Test Fail");
        }

        // Test with invalid date format
        var invalidDateStr = "not-a-date";
        if (!InputValidator.IsValidDate(invalidDateStr, out dueDate))
        {
            Console.WriteLine("IsValidDate Format Test Pass");
        }
        else
        {
            Console.WriteLine("IsValidDate Format Test Fail");
        }
    }
}//pass