using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentApp.API.Dtos.Cars;
using CarRentApp.Domain;

namespace CarRentApp.API.Services.Interfaces
{
     public interface ICarService
     {
          Task<ICollection<Car>> GetCars();
          Task<Car> GetCarById(int id);
          Task<Car> AddNewCar(CreateCarDto newCar);
          Task<bool> RemoveCarById(int id);
          Task<Car> UpdateCar(int id, UpdateCarDto updatedCar);
     }
}
