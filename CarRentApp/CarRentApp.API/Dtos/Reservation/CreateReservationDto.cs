using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Dtos.Reservation
{
     public class CreateReservationDto
     {
          [Required]
          public DateTime StartDate { get; set; }
          [Required]
          public DateTime EndDate { get; set; }
          [Required]
          public int CarId { get; set; }
     }
}
