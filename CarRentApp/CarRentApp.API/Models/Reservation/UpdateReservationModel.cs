using System;

namespace CarRentApp.API.Models.Reservation
{
     public class UpdateReservationModel
     {
          public DateTime? StartDate { get; set; }
          public DateTime? EndDate { get; set; }
     }
}
