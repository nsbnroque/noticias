using System;

namespace Auth.Models
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;

        private string _role;

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
        public int id {get => _id; set => _id = value;}
        public string role {get => _role; set => _role = value;}
    }
}
