using System;
using CarRentApp.Domain.Auth;

namespace CarRentApp.Domain
{
     public class Reservation : EntityBase
     {
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public int ClientId { get; set; }
          public Client Client { get; set; }
          public int CarId { get; set; }
          public Car Car { get; set; }
     }
}
