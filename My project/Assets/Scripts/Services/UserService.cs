using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using MonJeu.Models;
using System;
using System.Text;
using Newtonsoft.Json;
using UnityEditor.UIElements;

namespace MonJeu.Services
{
public class UserService 
{
    private string apiBaseUrl = "http://localhost:5267/";

    

    // Créer un utilisateur
    public IEnumerator CreateUser(User user)
    {
        string json = JsonUtility.ToJson(user);


         yield return SendRequest("CreateUser", json,"POST");
    }

    // Modifier un utilisateur (ex. changer email)
    public IEnumerator UpdateUser(long Id, User newUser)
    {

            User updaterUser = new User(Id, newUser.Username, newUser.Email, newUser.Password);

            string json = JsonUtility.ToJson(updaterUser);


            yield return SendRequest("UpdateUser",json,"PUT");
    }

    // Supprimer un utilisateur
    public IEnumerator DeleteUser(long id)
    {
        string endpoint = $"deleteUser/{id}";
        UnityWebRequest request = UnityWebRequest.Delete(apiBaseUrl + endpoint);
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Utilisateur supprimé avec succès.");
        }
        else
        {
            Debug.LogError($"Erreur DELETE : {request.responseCode} - {request.error}");
        }
    }



    private IEnumerator SendRequest(string endpoint, string json, string RequestType)
    {

        UnityWebRequest request = new UnityWebRequest(apiBaseUrl + endpoint, RequestType);
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
}
}
