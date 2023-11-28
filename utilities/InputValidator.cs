using System;
using System.Text.RegularExpressions;

namespace TaskManager.utilities;

public static class InputValidator
{
    public static bool IsValidUsername(string username)
    {
        return !string.IsNullOrWhiteSpace(username) && username.Length >= 3 && username.Length <= 20;
    }

    public static bool IsValidPassword(string password)
    {
        return !string.IsNullOrWhiteSpace(password) && password.Length >= 6 && password.Length <= 20;
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        return emailRegex.IsMatch(email);
    }
}