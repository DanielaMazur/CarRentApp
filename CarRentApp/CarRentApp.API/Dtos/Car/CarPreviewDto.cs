using CarRentApp.API.Dtos.Photo;
using System.Collections.Generic;

namespace CarRentApp.API.Dtos.Car
{
     public class CarPreviewDto
     {
          public int Id { get; set; }
          public string Brand { get; set; }
          public string Model { get; set; }
          public ICollection<PhotoDto> Photos { get; set; }
          public decimal PricePerDay { get; set; }
     }
}
