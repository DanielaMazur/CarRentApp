using CarRentApp.Domain.Intefaces;

namespace CarRentApp.Domain
{
     public class Transmission : IEntity
     {
          public int Id { get; set; }
          public string Type { get; set; }
     }
}
