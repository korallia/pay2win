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
        //user = new User("abyssal_knight_3", "knight@abyss.com", "ShadowBlade42");
        userService = new UserService();
       
       //StartCoroutine(userService.CreateUser(user));
        //Debug.Log(user.Username + " " + user.Password + " " + user.Email);

       //newUser = new User("test_updated", "test_now@example.com", "password");
        //StartCoroutine(userService.UpdateUser(20014,newUser ));
        //Debug.Log(user.Username + " " + user.Password + " " + user.Email);

        //StartCoroutine(userService.DeleteUser(20014));
        LoginModel login = new LoginModel("abyssal_knight_renamed", "NewShadowPass99!");
        StartCoroutine(userService.Login(login));


    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
