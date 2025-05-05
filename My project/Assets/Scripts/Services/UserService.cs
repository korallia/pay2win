using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using MonJeu.Models;
using System;

public class UserService : MonoBehaviour
{
    private string apiBaseUrl = "http://tonserveur.com/api/";

    // Créer un utilisateur
    public IEnumerator CreateUser(User user)
    {
        string json = JsonUtility.ToJson(new
        {
            username = user.Username,
            email = user.Email,
            password = user.PasswordHash
        });

        yield return SendRequest("saveUser", json);
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

        yield return SendRequest("deleteUser", json);
    }

    // Changer le mot de passe
    public IEnumerator ChangePassword(User user, string newPassword)
    {
        user.SetPassword(newPassword);
        string json = JsonUtility.ToJson(new
        {
            username = user.Username,
            newPassword = user.PasswordHash
        });

        yield return SendRequest("changePassword", json);
    }

    // Méthode générique pour envoyer une requête POST
    private IEnumerator SendRequest(string endpoint, string json)
    {
        UnityWebRequest request = UnityWebRequest.Put(apiBaseUrl + endpoint, json);
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
