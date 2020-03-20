using Core.Entities;
using Core.Webapi.Helpers;

namespace Core.Webapi.Models
{
    public class Converter
    {
        public static User GetUser(UserModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                EmailId = model.Email,
                Password = Hasher.GetHash(model.Password)
            };

            return user;
        }
    }
}
