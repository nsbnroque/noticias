using System;

namespace Auth.Models
{
    public class User
    {
        private string _username;
        private string _password;

        public User()
        {
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public string username { get => _username; set => _username = value; }
        public string password { get => _password; set => _password = value; }
    }
}
