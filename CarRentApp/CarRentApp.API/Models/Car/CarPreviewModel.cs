using CarRentApp.API.Models.Photo;
using System.Collections.Generic;

namespace CarRentApp.API.Models.Car
{
     public class CarPreviewModel
     {
          public int Id { get; set; }
          public string Brand { get; set; }
          public string Model { get; set; }
          public ICollection<PhotoModel> Photos { get; set; }
          public decimal PricePerDay { get; set; }
     }
}
