using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Models.User
{
     public class UserRegistrerModel
     {
          [Required]
          public string LastName { get; set; }
          [Required]
          public string FirstName { get; set; }
          [Required]
          public string Email { get; set; }

          [Required]
          public string Password { get; set; }
     }
}
