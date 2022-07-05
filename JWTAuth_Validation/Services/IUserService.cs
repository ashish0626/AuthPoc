using JWTAuth_Validation.Controllers;
using JWTAuth_Validation.Model;

namespace JWTAuth_Validation.Services
{
    public interface IUserService
    {
        bool IsValidUserInformation(LoginModel model);
        LoginModel GetUserDetails();
        EmployeeModel Find(string userName, string password);
    }
}
