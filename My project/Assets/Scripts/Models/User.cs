using System;
using System.Security.Cryptography;

namespace MonJeu.Models
{
public class User
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        SetPassword(password);
    }

    public void SetPassword(string password)
    {
        PasswordHasher.CreatePasswordHash(password, out byte[] hash, out byte[] salt);
        PasswordHash = hash;
        PasswordSalt = salt;
    }

    public bool CheckPassword(string password)
    {
        return PasswordHasher.VerifyPassword(password, PasswordHash, PasswordSalt);
    }

    // 🔐 Classe utilitaire interne pour le hash
    private static class PasswordHasher
    {
        public static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                hash = pbkdf2.GetBytes(32);
            }
        }

        public static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                return CryptographicOperations.FixedTimeEquals(hash, storedHash);
            }
        }
    }
}
}