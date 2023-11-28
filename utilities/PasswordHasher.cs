using System;
using System.Security.Cryptography;
using System.Text;

namespace TaskManager.utilities;

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