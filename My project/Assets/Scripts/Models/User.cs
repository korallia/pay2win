using System;
using System.Data.Common;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

namespace MonJeu.Models
{
 [Serializable]
public class User
{

    public long Id;
    public   string Username ;
    public  string Email ;
    public string  Password;



    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }

    public User( long  id ,String username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
    }

/*
    

  


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

    
    }
      */
    
}
}