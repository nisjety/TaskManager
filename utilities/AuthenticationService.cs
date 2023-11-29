//eksempel from: https://juldhais.net/secure-way-to-store-passwords-in-database-using-sha256-asp-net-core-898128d1c4ef
using System.Security.Cryptography; // added for password hashing.
using System.Text;
using TaskManager.database;

namespace TaskManager.utilities
{
    // user authentication including password verification.
    public class AuthenticationService
    {
        private readonly SQLiteDatabaseManager _dbManager;

        // Initializes the AuthenticationService with a reference to the database manager.
        public AuthenticationService(SQLiteDatabaseManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        // checks user login info against stored data.
        public bool VerifyLogin(string username, string enteredPassword)
        {
            // gets user data from the database by username.
            var user = _dbManager.GetUserByUsername(username);

            // Compares the entered password with the stored password hash.
            if (user != null)
            {
                return PasswordHasher.VerifyPassword(enteredPassword, user.Password);
            }
            return false;
        }

        // handles password hashing and verification.
        public static class PasswordHasher
        {
            // hashes password using SHA256.
            public static string HashPassword(string password)
            {
                using var sha256 = SHA256.Create();// Generates a hashed password using SHA256.
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }

            // Verifies the entered password against the stored password hash.
            public static bool VerifyPassword(string enteredPassword, string storedHash)
            {
                string enteredHash = HashPassword(enteredPassword);
                return enteredHash == storedHash;
            }
        }
    }
}


