using System;

namespace CarRentApp.API.Dtos.Reservation
{
     public class UpdateReservationDto
     {
          public DateTime? StartDate { get; set; }
          public DateTime? EndDate { get; set; }
     }
}
