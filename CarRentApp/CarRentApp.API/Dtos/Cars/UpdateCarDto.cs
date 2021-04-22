using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRentApp.API.Dtos.Photos;
using CarRentApp.API.Infrastructure.Annotations;
using CarRentApp.Domain.Enums;

namespace CarRentApp.API.Dtos.Cars
{
     public class UpdateCarDto
     {
          public string Brand { get; set; }
          public string Color { get; set; }
          public Fuel? Fuel { get; set; }
          public Transmission? Transmission { get; set; }
          public CarBody? Body { get; set; }
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
