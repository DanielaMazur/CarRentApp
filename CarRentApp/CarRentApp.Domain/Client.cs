using CarRentApp.Domain.Auth;
using CarRentApp.Domain.Intefaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentApp.Domain
{
     public class Client : IEntity
     {
          public string DriverLicenseId { get; set; }
          public ICollection<Reservation> Reservations { get; set; }
          [Key]
          [ForeignKey("User")]
          public int Id { get; set; }
          public User User { get; set; }
     }
}
