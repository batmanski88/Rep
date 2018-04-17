using System;

namespace Repository.Models
{
    public class User
    {
        public Guid UserId {get; protected set;}
        public string Username {get; protected set;}
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public string Salt {get; protected set;}
        public string Roles {get; protected set;}

        protected User()
        {

        }

        public User(Guid userId, string username, string email, string password, string salt, string roles)
        {

        }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetSalt(string salt)
        {
            Salt = salt;
        }

        public void SetRoles(string roles)
        {
            Roles = roles;
        }
    }
}