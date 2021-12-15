using System.Collections.Generic;

namespace JwtTokenPoc.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "hpe", EmailAddress = "hpe.admin@email.com", Password = "hpe", GivenName = "hpe", Surname = "hpe", Role = "Administrator" },
            new UserModel() { Username = "ashish", EmailAddress = "ashish.admin@email.com", Password = "ashish", GivenName = "ashish", Surname = "chourasia", Role = "Administrator" },
            new UserModel() { Username = "developers", EmailAddress = "developers.developers@email.com", Password = "developers", GivenName = "developers", Surname = "developers", Role = "Developers" },
        };
    }
}
