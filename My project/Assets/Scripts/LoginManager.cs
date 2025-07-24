using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField Username_Input;
    public TMP_InputField Password_Input;

    public void OnLoginButtonClicked()
    {
        string username = Username_Input.text;
        string password = Password_Input.text;

        StartCoroutine(Login(username, password));
    }

    IEnumerator Login(string username, string password)
    {
        string jsonData = JsonUtility.ToJson(new LoginData(username, password));
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        UnityWebRequest request = new UnityWebRequest("http://localhost:5267/login", "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Réponse serveur: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Erreur de connexion: " + request.error + "\n" + request.downloadHandler.text);
        }
    }

    [System.Serializable]
    public class LoginData
    {
        public string username;
        public string password;
        public LoginData(string user, string pass)
        {
            username = user;
            password = pass;
        }
    }
}
