using System;
using CarRentApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using CarRentApp.API.Infrastructure.Annotations;

namespace CarRentApp.API.Models.Car
{
     public class CreateCarModel
     {
          [Required]
          public string Brand { get; set; }
          [Required]
          public string Color { get; set; }
          [Required]
          public FuelEnum FuelId { get; set; }
          [Required]
          public TransmissionEnum TransmissionId { get; set; }
          [Required]
          public CarBodyEnum CarBodyId { get; set; }
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
     }
}
