using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Services
{
     public class CarFiltersService : ICarFiltersService
     {
          private readonly IRepository _repository;

          public CarFiltersService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<ICollection<Transmission>> GetTransmissions()
          {
               return await _repository.GetAll<Transmission>();
          }

          public async Task<ICollection<Fuel>> GetFuel()
          {
               return await _repository.GetAll<Fuel>();
          }

          public async Task<ICollection<CarBody>> GetCarBody()
          {
               return await _repository.GetAll<CarBody>();
          }
     }
}
