using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Dtos.Account
{
     public class CreateClientDto
     {
          [Required]
          public string DriverLicenceId { get; set; }
     }
}
