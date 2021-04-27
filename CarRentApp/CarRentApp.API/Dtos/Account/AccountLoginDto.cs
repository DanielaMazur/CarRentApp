
using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Dtos.Account
{
     public class AccountLoginDto
     {
          [Required]
          public string Email { get; set; }

          [Required]
          public string Password { get; set; }

     }
}
