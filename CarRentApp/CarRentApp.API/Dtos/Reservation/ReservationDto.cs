using CarRentApp.API.Dtos.Car;
using System;

namespace CarRentApp.API.Dtos.Reservation
{
     public class ReservationDto
     {
          public int Id { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public CarPreviewDto Car { get; set; }
     }
}
