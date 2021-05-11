using CarRentApp.Domain.Intefaces;
using System;

namespace CarRentApp.Domain
{
     public class Reservation : IEntity
     {
          public int Id { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public int ClientId { get; set; }
          public Client Client { get; set; }
          public int CarId { get; set; }
          public Car Car { get; set; }
     }
}
