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
    User newUser;
    UserService userService;
    // Start is called before the first frame update
    void Start()
    {
        user = new User("test_created", "test_now@example.com", "password1235");
        userService = new UserService();
        StartCoroutine(userService.DeleteUser(2));
       
       //StartCoroutine(userService.CreateUser(user));
        //Debug.Log(user.Username + " " + user.Password + " " + user.Email);

       //newUser = new User("test_updated", "test_now@example.com", "password");
        //StartCoroutine(userService.UpdateUser(user.Id,newUser ));
        //Debug.Log(user.Username + " " + user.Password + " " + user.Email);

        


    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
