using CarRentApp.Domain.Auth;
using System;

namespace CarRentApp.Domain
{
     public class Reservation : EntityBase
     {
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public int UserId { get; set; }
          public User User { get; set; }
          public int CarId { get; set; }
          public Car Car { get; set; }
     }
}
