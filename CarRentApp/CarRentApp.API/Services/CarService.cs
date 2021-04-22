using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentApp.API.Dtos.Cars;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;

namespace CarRentApp.API.Services
{
     public class CarService : ICarService
     {
          private IRepository _repository;

          public CarService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<ICollection<Car>> GetCars()
          {
               return await _repository.GetAllWithInclude<Car>(c => c.Photos);
          }

          public async Task<Car> GetCarById(int id)
          {
               var car = await _repository.GetById<Car>(id);

               if (car == null)
               {
                    throw new NotFoundException("A car with such Id was not found!");
               }

               return car;
          }

          public async Task<Car> AddNewCar(CreateCarDto newCar)
          {
               if (await CheckIfRegistrationNumberExists(newCar.RegistrationNumber))
               {
                    throw new EntryAlreadyExistsException("A car with such Registration Number already exists!");
               }

               var createdCar = new Car()
               {
                    Brand = newCar.Brand,
                    Color = newCar.Color,
                    Fuel = newCar.Fuel,
                    Transmission = newCar.Transmission,
                    Body = newCar.Body,
                    FabricationYear = newCar.FabricationYear,
                    RegistrationNumber = newCar.RegistrationNumber,
                    Model = newCar.Model,
                    NumberOfSeats = newCar.NumberOfSeats,
                    NumberOfDoors = newCar.NumberOfDoors,
                    AirCoditioning = newCar.AirCoditioning,
                    PricePerDay = newCar.PricePerDay,
               };

               _repository.Add(createdCar);
               await _repository.SaveAll();

               return createdCar;
          }

          public async Task<bool> RemoveCarById(int id)
          {
               var carToDelete = await _repository.GetById<Car>(id);

               if (carToDelete == null)
               {
                    return false;
               }

               await _repository.Delete<Car>(id);

               await _repository.SaveAll();

               return true;
          }

          public async Task<Car> UpdateCar(int id, UpdateCarDto updatedCar)
          {
               var car = await _repository.GetById<Car>(id);

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

               if (updatedCar.Fuel.HasValue)
               {
                    car.Fuel = updatedCar.Fuel.Value;
               }

               if (updatedCar.Transmission.HasValue)
               {
                    car.Transmission = updatedCar.Transmission.Value;
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

               if (updatedCar.Body.HasValue)
               {
                    car.Body = updatedCar.Body.Value;
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

               _repository.Update(car);
               await _repository.SaveAll();

               return car;
          }

          public async Task<bool> CheckIfRegistrationNumberExists(string registrationNumber)
          {

               try
               {
                    var cars = await _repository.GetAll<Car>();
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
