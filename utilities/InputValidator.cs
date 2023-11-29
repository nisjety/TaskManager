using System.Text.RegularExpressions;

namespace TaskManager.utilities
{
    // Provides static methods for validating various user inputs like username, password, and email.
    public class InputValidator
    {
        // Validates a username to make sure it's not empty and within a specific character range.
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username) && username.Length is >= 3 and <= 20;
        }

        // Validates a password to to make sure it's not empty and within a specific character range.
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length is >= 6 and <= 20;
        }

        // Validates an email to make sure it follows a standard email format with @.
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        // Validates a task title to make sure it's not empty and does not exceed a certain length of 10 char.
        public static bool IsValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title) && title.Length <= 10; //  limit
        }

        // Validates a task note to make sure it does not exceed a certain length here is 1000 char.
        public static bool IsValidNote(string? note)
        {
            return note is not { Length: > 1000 }; // limit
        }

        // Validates a date string, make sure it's a valid date and is set in the future.
        public static bool IsValidDate(string dateString, out DateTime dueDate)
        {
            return DateTime.TryParse(dateString, out dueDate) && dueDate > DateTime.Now;
        }
    }
}