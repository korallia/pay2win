using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using MonJeu.Models;
using MonJeu.Services;
using System;
//using System.Diagnostics;


public class UserTest : MonoBehaviour
{
    User user;
    UserService userService;
    // Start is called before the first frame update
    void Start()
    {
        user = new User("test", "test@example.com", "password123");
        userService = new UserService();

       
        StartCoroutine(userService.CreateUser(user));
        Debug.Log(user.Username + " " + user.Password + " " + user.Email);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
