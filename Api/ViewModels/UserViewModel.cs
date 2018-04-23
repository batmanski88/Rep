using System;

namespace Api.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Salt {get; set;}
        public string Roles {get; set;}
    }
}