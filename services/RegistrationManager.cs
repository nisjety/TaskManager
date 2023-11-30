using TaskManager.database;
using TaskManager.models;
using TaskManager.utilities;

namespace TaskManager.services
{
    // Manages the user registration process, including input validation and storage it in the database.
    public class RegistrationManager
    {
        private SQLiteDatabaseManager _dbManager;

        // Initializes the RegistrationManager with a database manager.
        public RegistrationManager(SQLiteDatabaseManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        // handles the user registration process including data validation and user creation.
        public bool RegisterHandler()
        {
            Console.WriteLine("Please write your username:");
            var username = Console.ReadLine()?.Trim(); // methode to Trim whitespace and handles null inputs.

            // checks username so it is not empty.
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return false;
            }

            if (!InputValidator.IsValidUsername(username))
            {
                Console.WriteLine("Invalid username format. Please try again.");
                return false;
            }

            // checks username if it already is  in the database.
            if (_dbManager.UsernameExists(username))
            {
                Console.WriteLine("Username already in use. Please try a different username.");
                return false;
            }

            Console.WriteLine("Please write your password:");
            var password = Console.ReadLine();

            // checks password so it is not empty.
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            if (!InputValidator.IsValidPassword(password))
            {
                Console.WriteLine("Invalid password format. Please try again.");
                return false;
            }

            Console.WriteLine("Please write your email:");
            var email = Console.ReadLine()?.Trim(); // methode to Trim whitespace and handles null inputs.

            // checks email so it is not empty.
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return false;
            }

            if (!InputValidator.IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format. Please try again.");
                return false;
            }

            // Checks if the email already exists in the database.
            if (_dbManager.EmailExists(email))
            {
                Console.WriteLine("Email already in use. Please try a different email.");
                return false;
            }

            try
            {
                // Hashes the password and creates a new user.
                var hashedPassword = AuthenticationService.PasswordHasher.HashPassword(password);
                var user = new User(username, hashedPassword, email);

                // Adds the new user to the database.
                _dbManager.CreateUser(user);
                Console.WriteLine("Registration successful! Returning to main menu...");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during registration: {ex.Message}");
                return false; // Indicates failure because to an exception.
            }
        }
    }
}
