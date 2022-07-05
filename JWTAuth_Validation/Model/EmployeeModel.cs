using System.ComponentModel.DataAnnotations;

namespace JWTAuth_Validation.Model
{
    public class EmployeeModel
    {
        
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EmailID { get; set; }
        [Required]
        public string EmployeePassword { get; set; }
        [Required]
        public string EmployeeRole { get; set; }



    }
}
