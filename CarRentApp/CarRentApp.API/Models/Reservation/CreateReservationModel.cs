using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Models.Reservation
{
     public class CreateReservationModel
     {
          [Required]
          public DateTime StartDate { get; set; }
          [Required]
          public DateTime EndDate { get; set; }
          [Required]
          public int CarId { get; set; }
     }
}
