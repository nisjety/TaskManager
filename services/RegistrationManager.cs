using TaskManager.models;
using TaskManager.database;
using TaskManager.utilities;

namespace TaskManager.services;

public class RegistrationManager
{
    private readonly SQLiteDatabaseManager _dbManager;

    public RegistrationManager(SQLiteDatabaseManager dbManager)
    {
        _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
    }

    // Handles the user registration process
    public void RegisterHandler()
    {
        Console.WriteLine("Please write your username:");
        var username = Console.ReadLine();

        if (username != null && !InputValidator.IsValidUsername(username))
        {
            Console.WriteLine("Invalid username format. Please try again.");
            return;
        }

        if (_dbManager.UsernameExists(username))
        {
            Console.WriteLine("Username already in use. Please try a different username.");
            return;
        }

        Console.WriteLine("Please write your password:");
        var password = Console.ReadLine();

        if (password != null && !InputValidator.IsValidPassword(password))
        {
            Console.WriteLine("Invalid password format. Please try again.");
            return;
        }

        Console.WriteLine("Please write your email:");
        var email = Console.ReadLine();

        if (email != null && !InputValidator.IsValidEmail(email))
        {
            Console.WriteLine("Invalid email format. Please try again.");
            return;
        }

        if (_dbManager.EmailExists(email))
        {
            Console.WriteLine("Email already in use. Please try a different email.");
            return;
        }

        var hashedPassword = AuthenticationService.PasswordHasher.HashPassword(password);
        var user = new User(username, hashedPassword, email);

        _dbManager.CreateUser(user);
        Console.WriteLine("Registration successful!");

        // Call the method to display the main menu
        Program.DisplayMenu();
    }
}
