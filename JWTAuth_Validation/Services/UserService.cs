using JWTAuth_Validation.Controllers;

namespace JWTAuth_Validation.Services
{
    public class UserService : IUserService
    {
        public bool IsValidUserInformation(LoginModel model)
        {
            if (model.UserName.Equals("hpe") && model.Password.Equals("hpe")) return true;
            else return false;
        }

        public LoginModel GetUserDetails()
        {
            return new LoginModel { UserName = "hpe", Password = "hpe" };
        }
    }
}
