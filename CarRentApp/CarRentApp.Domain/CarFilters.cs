using System.Collections.Generic;

namespace CarRentApp.Domain
{
     public class CarFilters
     {
          public ICollection<Transmission> Transmission { get; set;} 
          public ICollection<Fuel> Fuel { get; set; } 
          public ICollection<CarBody> CarBody { get; set; }
     }
}

