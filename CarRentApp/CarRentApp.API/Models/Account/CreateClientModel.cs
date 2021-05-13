using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Models.Account
{
     public class CreateClientModel
     {
          [Required]
          public string DriverLicenceId { get; set; }
     }
}
