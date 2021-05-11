using System.Collections.Generic;

namespace CarRentApp.API.Dtos.CarFilters
{
     public class CarFiltersDto
     {
          public ICollection<TransmissionDto> Transmission { get; set; }
          public ICollection<CarBodyDto> CarBody { get; set; }
          public ICollection<FuelDto> Fuel { get; set; }
     }
}
