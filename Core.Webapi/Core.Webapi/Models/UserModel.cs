using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Webapi.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public bool IsActivated { get; set; }

        public bool IsDeleted  { get; set; }

        public UserModel()
        {

        }

        public UserModel(User user, string token)
        {
            UserId = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.EmailId;
            Username = user.UserName;
            Token = token;
            IsActivated = user.IsActivated;
            IsDeleted = user.RemovedOn != null;
        }
    }
}
