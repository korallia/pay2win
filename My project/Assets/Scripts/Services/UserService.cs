using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using MonJeu.Models;
using System;
using System.Text;
using Newtonsoft.Json;

namespace MonJeu.Services
{
public class UserService 
{
    private string apiBaseUrl = "http://localhost:5267/";

    

    // Créer un utilisateur
    public IEnumerator CreateUser(User user)
    {
        //Debug.Log("IN create User");
        //Debug.Log(user.Username + " " + user.Password + " " + user.Email);

        // Sérialiser l'objet User en JSON
        string json = JsonUtility.ToJson(user);


        // Créer la requête POST
        Debug.Log("JSON envoyé : " + json);
        UnityWebRequest request = new UnityWebRequest(apiBaseUrl + "createUser", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Envoyer la requête et attendre la réponse
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Succès : " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Erreur : " + request.error);
        }
    }

    // Modifier un utilisateur (ex. changer email)
    public IEnumerator UpdateUser(User user)
    {
        string json = JsonUtility.ToJson(new
        {
            username = user.Username,
            email = user.Email
        });

        yield return SendRequest("updateUser", json);
    }

    // Supprimer un utilisateur
    public IEnumerator DeleteUser(User user)
    {
        string json = JsonUtility.ToJson(new
        {
            username = user.Username
        });

        yield return SendRequest("/remove/{id}", json);
    }

    // Changer le mot de passe
/*
    public IEnumerator ChangePassword(User user, string newPassword)
    {
        user.SetPassword(newPassword);
        string json = JsonUtility.ToJson(new
        {
            username = user.Username,
            newPassword = user.PasswordHash
        });

        yield return SendRequest("updateUser", json);
    }
    */

    // Méthode générique pour envoyer une requête POST
    private IEnumerator SendRequest(string endpoint, string json)
    {
        UnityWebRequest request = UnityWebRequest.Post(apiBaseUrl + endpoint, json);
        request.method = UnityWebRequest.kHttpVerbPOST;
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Succès : " + endpoint + " => " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Erreur (" + endpoint + ") : " + request.error);
        }
    }
}
}
