using System;
using System.Collections.Generic;
using CarRentApp.API.Dtos.Photo;
using CarRentApp.API.Dtos.Reservation;

namespace CarRentApp.API.Dtos.Car
{
     public class CarDto
     {
          public int Id { get; set; }
          public string Brand { get; set; }
          public string Color { get; set; }
          public string Fuel { get; set; }
          public string Transmission { get; set; }
          public string Body { get; set; }
          public DateTime FabricationYear { get; set; }
          public string RegistrationNumber { get; set; }
          public string Model { get; set; }
          public byte NumberOfSeats { get; set; }
          public byte NumberOfDoors { get; set; }
          public bool AirCoditioning { get; set; }
          public ICollection<PhotoDto> Photos { get; set; }
          public decimal PricePerDay { get; set; }
          public ICollection<ReservationDto> Reservations { get; set; }
     }
}
