using System;
using System.Security.Cryptography;
using UnityEngine;

namespace MonJeu.Models
{
 [Serializable]
public class User
{
    
    public long Id { get; set; }
    public   string Username ;
    public  string Email ;
    private byte[] PasswordSalt { get;  set; }
     private byte[] PasswordHash { get;  set; }


//base 64 string 
    public string  Password;



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
        Password = Convert.ToBase64String(hash);
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