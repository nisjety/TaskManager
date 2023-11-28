using System;
using System.Security.Cryptography;
using System.Text;
using TaskManager.database;

namespace TaskManager.utilities;

public class AuthenticationService
{
    private readonly SQLiteDatabaseManager _dbManager;

    public AuthenticationService(SQLiteDatabaseManager dbManager)
    {
        _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
    }

    public bool Login(string username, string password)
    {
        var user = _dbManager.GetUserByUsername(username);
        if (user != null && PasswordHasher.VerifyPassword(password, user.Password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}

