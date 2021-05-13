using System;
using System.Collections.Generic;
using CarRentApp.API.Models.Photo;
using CarRentApp.API.Models.Reservation;

namespace CarRentApp.API.Models.Car
{
     public class CarModel
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
          public ICollection<PhotoModel> Photos { get; set; }
          public decimal PricePerDay { get; set; }
          public ICollection<ReservationModel> Reservations { get; set; }
     }
}
