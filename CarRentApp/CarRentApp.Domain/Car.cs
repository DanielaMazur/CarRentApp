using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarRentApp.Domain.Enums;

namespace CarRentApp.Domain
{
     public class Car : EntityBase
     {
          public string Brand { get; set; }
          public string Color { get; set; }
          public FuelEnum FuelId { get; set; }
          public Fuel Fuel { get; set; }
          public TransmissionEnum TransmissionId { get; set; }
          public Transmission Transmission { get; set; }
          public CarBodyEnum CarBodyId { get; set; }
          public CarBody CarBody { get; set; }
          public DateTime FabricationYear { get; set; }
          public string RegistrationNumber { get; set; }
          public string Model { get; set; }
          public byte NumberOfSeats { get; set; }
          public byte NumberOfDoors { get; set; }
          public bool AirCoditioning { get; set; }
          public ICollection<Photo> Photos { get; set; }

          [Column(TypeName = "Money")]
          public decimal PricePerDay { get; set; }
          public ICollection<Reservation> Reservations { get; set; }
     }
}
