using System;
using System.Collections.Generic;
using CarRentApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using CarRentApp.API.Infrastructure.Annotations;
using CarRentApp.API.Dtos.Photos;

namespace CarRentApp.API.Dtos.Cars
{
     public class CreateCarDto
     {
          [Required]
          public string Brand { get; set; }
          [Required]
          public string Color { get; set; }
          [Required]
          public Fuel Fuel { get; set; }
          [Required]
          public Transmission Transmission { get; set; }
          [Required]
          public CarBody Body { get; set; }
          [Required]
          [YearRange(1950)]
          public DateTime FabricationYear { get; set; }
          [Required]
          public string RegistrationNumber { get; set; }
          [Required]
          public string Model { get; set; }
          [Required]
          public byte NumberOfSeats { get; set; }
          [Required]
          public byte NumberOfDoors { get; set; }
          [Required]
          public bool AirCoditioning { get; set; }
          [Required]
          [Range(0, 999)]
          public decimal PricePerDay { get; set; }
          
          public ICollection<PhotoDto> Photos { get; set; }

     }
}
