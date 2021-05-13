
using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Models.User
{
     public class UserLoginModel
     {
          [Required]
          public string Email { get; set; }

          [Required]
          public string Password { get; set; }

     }
}
