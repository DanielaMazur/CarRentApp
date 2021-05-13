using CarRentApp.API.Models.Car;
using System;

namespace CarRentApp.API.Models.Reservation
{
     public class ReservationModel
     {
          public int Id { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public CarPreviewModel Car { get; set; }
     }
}
