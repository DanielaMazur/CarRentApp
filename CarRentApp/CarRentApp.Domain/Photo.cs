using CarRentApp.Domain.Intefaces;

namespace CarRentApp.Domain
{
     public class Photo : IEntity
     {
          public int Id { get; set; }
          public int CarId { get; set; }
          public string Path { get; set; }
     }
}
