using System;
using System.ComponentModel.DataAnnotations;
using CarRentApp.API.Infrastructure.Annotations;
using CarRentApp.Domain.Enums;

namespace CarRentApp.API.Dtos.Car
{
     public class UpdateCarDto
     {
          public string Brand { get; set; }
          public string Color { get; set; }
          public FuelEnum? FuelId { get; set; }
          public TransmissionEnum? TransmissionId { get; set; }
          public CarBodyEnum? CarBodyId { get; set; }
          [YearRange(1950)]
          public DateTime? FabricationYear { get; set; }
          public string RegistrationNumber { get; set; }
          public string Model { get; set; }
          public byte? NumberOfSeats { get; set; }
          public byte? NumberOfDoors { get; set; }
          public bool? AirCoditioning { get; set; }
          [Range(0, 999)]
          public decimal? PricePerDay { get; set; }
     }
}
