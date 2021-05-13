using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;
using CarRentApp.Domain.EFMapping.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Services
{
     public class CarFiltersService : ICarFiltersService
     {
          private readonly ITransmissionRepository _transmissionRepository;
          private readonly ICarBodyRepository _carBodyRepository;
          private readonly IFuelRepository _fuelRepository;

          public CarFiltersService(ITransmissionRepository transmissionRepository, ICarBodyRepository carBodyRepository, IFuelRepository fuelRepository)
          {
               _transmissionRepository = transmissionRepository;
               _carBodyRepository = carBodyRepository;
               _fuelRepository = fuelRepository;
          }

          public async Task<ICollection<Transmission>> GetTransmissions()
          {
               return await _transmissionRepository.GetAll();
          }

          public async Task<ICollection<Fuel>> GetFuel()
          {
               return await _fuelRepository.GetAll();
          }

          public async Task<ICollection<CarBody>> GetCarBody()
          {
               return await _carBodyRepository.GetAll();
          }
     }
}
