using CarRentApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Services.Interfaces
{
     public interface ICarFiltersService
     {
          Task<ICollection<Transmission>> GetTransmissions();
          Task<ICollection<Fuel>> GetFuel();
          Task<ICollection<CarBody>> GetCarBody();
     }
}
