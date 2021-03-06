using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentApp.API.Models.Car;
using CarRentApp.Domain;
using CarRentApp.Domain.Enums;

namespace CarRentApp.API.Services.Interfaces
{
     public interface ICarService
     {
          Task<ICollection<Car>> GetCars();
          Task<Car> GetCarById(int id);
          Task<Car> AddNewCar(CreateCarModel newCar);
          Task RemoveCarById(int id);
          Task<Car> UpdateCar(int id, UpdateCarModel updatedCar);
          Task<ICollection<Car>> GetFilteredCars(CarBodyEnum? carBodyId);

     }
}
