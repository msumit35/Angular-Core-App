using System;
using Core.Entities;

namespace Core.Entities
{
    public class User : CrudEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool IsActivated { get; set; }
    }
}
