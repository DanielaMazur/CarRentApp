using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentApp.API.Dtos.Car;
using CarRentApp.Domain;

namespace CarRentApp.API.Services.Interfaces
{
     public interface ICarService
     {
          Task<ICollection<Car>> GetCars();
          Task<Car> GetCarById(int id);
          Task<Car> AddNewCar(CreateCarDto newCar);
          Task RemoveCarById(int id);
          Task<Car> UpdateCar(int id, UpdateCarDto updatedCar);
     }
}
