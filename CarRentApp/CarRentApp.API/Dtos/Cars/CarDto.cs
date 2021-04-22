using System;
using System.Collections.Generic;
using CarRentApp.API.Dtos.Photos;
using CarRentApp.Domain;
using CarRentApp.Domain.Enums;

namespace CarRentApp.API.Dtos.Cars
{
     public class CarDto
     {
          public int Id { get; set; }
          public string Brand { get; set; }
          public string Color { get; set; }
          public Fuel Fuel { get; set; }
          public Transmission Transmission { get; set; }
          public CarBody Body { get; set; }
          public DateTime FabricationYear { get; set; }
          public string RegistrationNumber { get; set; }
          public string Model { get; set; }
          public byte NumberOfSeats { get; set; }
          public byte NumberOfDoors { get; set; }
          public bool AirCoditioning { get; set; }
          public ICollection<PhotoDto> Photos { get; set; }
          public decimal PricePerDay { get; set; }
          public ICollection<Reservation> Reservations { get; set; }
     }
}
