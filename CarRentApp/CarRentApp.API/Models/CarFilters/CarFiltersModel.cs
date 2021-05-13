using System.Collections.Generic;

namespace CarRentApp.API.Models.CarFilters
{
     public class CarFiltersModel
     {
          public ICollection<TransmissionModel> Transmission { get; set; }
          public ICollection<CarBodyModel> CarBody { get; set; }
          public ICollection<FuelModel> Fuel { get; set; }
     }
}
