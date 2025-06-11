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

    public User(String username, string password)
    {
        Username = username;
        Password = password;
    }
    

    
    
}
}