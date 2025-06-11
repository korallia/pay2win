using System;

namespace MonJeu.Models
{
    [Serializable]
    public class LoginModel
    {
        public string username;
        public string password;

        public LoginModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
