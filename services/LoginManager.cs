using TaskManager.models;
using TaskManager.database;
using TaskManager.utilities;


namespace TaskManager.services;

public class LoginManager
{
    private readonly SQLiteDatabaseManager _dbManager;

    public LoginManager(SQLiteDatabaseManager dbManager)
    {
        _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
    }

    // Handles the login process
    public bool LoginHandler(string username, string password)
    {
        try
        {
            var user = _dbManager.GetUserByUsername(username);

            if (user != null && AuthenticationService.PasswordHasher.VerifyPassword(password, user.Password))
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Login failed. Username or password is incorrect.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }
}