using CarRentApp.Domain.Intefaces;

namespace CarRentApp.Domain
{
     public class CarBody : IEntity
     {
          public int Id { get; set; }
          public string Type { get; set; }
     }
}
