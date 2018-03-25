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
    }
}