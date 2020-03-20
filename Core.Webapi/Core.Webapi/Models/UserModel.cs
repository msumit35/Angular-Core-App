using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Webapi.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public UserModel()
        {

        }

        public UserModel(User user, string token)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.EmailId;
            Username = user.UserName;
            Token = token;
        }
    }
}
