using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentApp.API.Models.Car;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;

namespace CarRentApp.API.Services
{
     public class CarService : ICarService
     {
          private readonly ICarRepository _carRepository;

          public CarService(ICarRepository carRepository)
          {
               _carRepository = carRepository;
          }

          public async Task<ICollection<Car>> GetCars()
          {
               return await _carRepository.GetCarsWithInclude(c => c.Photos, c => c.Reservations);
          }

          public async Task<Car> GetCarById(int id)
          {
               var cars = await _carRepository.GetCarsWithInclude(c => c.Photos);
               var car = cars.FirstOrDefault(c => c.Id == id);

               if (car == null)
               {
                    throw new NotFoundException("A car with such Id was not found!");
               }

               return car;
          }

          public async Task<Car> AddNewCar(CreateCarModel newCar)
          {
               if (await CheckIfRegistrationNumberExists(newCar.RegistrationNumber))
               {
                    throw new EntryAlreadyExistsException("A car with such Registration Number already exists!");
               }

               var createdCar = new Car()
               {
                    Brand = newCar.Brand,
                    Color = newCar.Color,
                    FuelId = newCar.FuelId,
                    TransmissionId = newCar.TransmissionId,
                    CarBodyId = newCar.CarBodyId,
                    FabricationYear = newCar.FabricationYear,
                    RegistrationNumber = newCar.RegistrationNumber,
                    Model = newCar.Model,
                    NumberOfSeats = newCar.NumberOfSeats,
                    NumberOfDoors = newCar.NumberOfDoors,
                    AirCoditioning = newCar.AirCoditioning,
                    PricePerDay = newCar.PricePerDay,
               };

               _carRepository.Add(createdCar);
               await _carRepository.SaveAll();

               return createdCar;
          }

          public async Task RemoveCarById(int id)
          {
               await _carRepository.Delete(id);

               await _carRepository.SaveAll();
          }

          public async Task<Car> UpdateCar(int id, UpdateCarModel updatedCar)
          {
               var car = await _carRepository.GetById(id);

               if (car == null)
               {
                    throw new NotFoundException("A car with such Id was not found!");
               }

               if (!string.IsNullOrEmpty(updatedCar.RegistrationNumber))
               {
                    if (await CheckIfRegistrationNumberExists(updatedCar.RegistrationNumber))
                    {
                         throw new EntryAlreadyExistsException("A car with such Registration Number already exists!");
                    }

                    car.RegistrationNumber = updatedCar.RegistrationNumber;
               }

               if (!string.IsNullOrEmpty(updatedCar.Color))
               {
                    car.Color = updatedCar.Color;
               }

               if (updatedCar.FuelId.HasValue)
               {
                    car.FuelId = updatedCar.FuelId.Value;
               }

               if (updatedCar.TransmissionId.HasValue)
               {
                    car.TransmissionId = updatedCar.TransmissionId.Value;
               }

               if (updatedCar.FabricationYear.HasValue)
               {
                    car.FabricationYear = updatedCar.FabricationYear.Value;
               }

               if (!string.IsNullOrEmpty(updatedCar.Model))
               {
                    car.Model = updatedCar.Model;
               }

               if (!string.IsNullOrEmpty(updatedCar.Brand))
               {
                    car.Brand = updatedCar.Brand;
               }

               if (updatedCar.CarBodyId.HasValue)
               {
                    car.CarBodyId = updatedCar.CarBodyId.Value;
               }

               if (updatedCar.AirCoditioning.HasValue)
               {
                    car.AirCoditioning = updatedCar.AirCoditioning.Value;
               }

               if (updatedCar.PricePerDay.HasValue)
               {
                    car.PricePerDay = updatedCar.PricePerDay.Value;
               }

               if (updatedCar.NumberOfDoors.HasValue)
               {
                    car.NumberOfDoors = updatedCar.NumberOfDoors.Value;
               }

               if (updatedCar.NumberOfSeats.HasValue)
               {
                    car.NumberOfSeats = updatedCar.NumberOfSeats.Value;
               }

               _carRepository.Update(car);
               await _carRepository.SaveAll();

               return car;
          }

          public async Task<bool> CheckIfRegistrationNumberExists(string registrationNumber)
          {

               try
               {
                    var cars = await _carRepository.GetAll();
                    var carWithTheSameRegistrationNumber = cars.Single(car => car.RegistrationNumber == registrationNumber);

                    return true;

               }
               catch (InvalidOperationException)
               {
                    return false;
               }

          }
     }
}
