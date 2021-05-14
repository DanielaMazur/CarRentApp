using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentApp.Domain;
using CarRentApp.Domain.EFMapping;
using CarRentApp.Domain.Enums;

namespace CarRentApp.API
{
     public class Seed
     {
          public static async Task SeedCars(CarRentAppDbContext context)
          {
               if (!context.Cars.Any())
               {
                    var car1 = new Car
                    {
                         Brand = "Toyota",
                         Color = "red",
                         FuelId = (int)FuelEnum.Diesel,
                         TransmissionId = (int)TransmissionEnum.Mecanic,
                         CarBodyId = (int)CarBodyEnum.Sedan,
                         FabricationYear = new DateTime(2015, 1, 1),
                         RegistrationNumber = "ABC123",
                         Model = "Corola",
                         NumberOfDoors = 4,
                         NumberOfSeats = 5,
                         AirCoditioning = true,
                         PricePerDay = 13,
                    };

                    var car2 = new Car
                    {
                         Brand = "Mercedes",
                         Color = "blue",
                         FuelId = (int)FuelEnum.Gasoline,
                         TransmissionId = (int)TransmissionEnum.Mecanic,
                         CarBodyId = (int)CarBodyEnum.Sedan,
                         FabricationYear = new DateTime(2017, 1, 1),
                         RegistrationNumber = "ASD512",
                         Model = "C-Class",
                         NumberOfDoors = 2,
                         NumberOfSeats = 4,
                         AirCoditioning = true,
                         PricePerDay = 15,
                    };


                    var car3 = new Car
                    {
                         Brand = "BMW",
                         Color = "grey",
                         FuelId = (int)FuelEnum.Gasoline,
                         TransmissionId = (int)TransmissionEnum.Automatic,
                         CarBodyId = (int)CarBodyEnum.Sedan,
                         FabricationYear = new DateTime(2016, 1, 1),
                         RegistrationNumber = "AFD988",
                         Model = "5-Series",
                         NumberOfDoors = 4,
                         NumberOfSeats = 5,
                         AirCoditioning = true,
                         PricePerDay = 20
                    };

                    context.Cars.Add(car1);
                    context.Cars.Add(car2);
                    context.Cars.Add(car3);

                    await context.SaveChangesAsync();
               }
          }

          public static async Task SeedPhotos(CarRentAppDbContext context)
          {
               if (!context.Photos.Any())
               {
                    var photos = new List<Photo>()
                    {
                         new Photo { Path = "https://localhost:44359/Cars/2017_mercedes_benz_c_class_angularfront.jpg", CarId = 2 },
                         new Photo { Path = "https://localhost:44359/Cars/2017_mercedes_benz_c_class_dashboard.jpg", CarId = 2 },
                         new Photo { Path = "https://localhost:44359/Cars/2017_mercedes_benz_c_class_trunk.jpg", CarId = 2 },
                         new Photo { Path = "https://localhost:44359/Cars/2015_Toyota_Corolla_15.jpg", CarId = 1 },
                         new Photo { Path = "https://localhost:44359/Cars/2015_toyota_corolla_angularfront.jpg", CarId = 1 },
                         new Photo { Path = "https://localhost:44359/Cars/2015_toyota_corolla_trunk.jpg", CarId = 1 },
                         new Photo { Path = "https://localhost:44359/Cars/2016_bmw_5_series_angularfront.jpg", CarId = 3 },
                         new Photo { Path = "https://localhost:44359/Cars/2016_bmw_5_series_dashboard.jpg", CarId = 3 },
                         new Photo { Path = "https://localhost:44359/Cars/2016_bmw_5_series_trunk.jpg", CarId = 3 }
                    };

                    foreach (var photo in photos)
                    {
                         context.Photos.Add(photo);
                    }

                    await context.SaveChangesAsync();
               }
          }
          public static async Task SeedTransmissions(CarRentAppDbContext context)
          {
               if (!context.Transmissions.Any())
               {
                    var transmissions = Enum.GetValues(typeof(TransmissionEnum))
                                             .OfType<TransmissionEnum>()
                                             .Select(x => new Transmission() { Id = (int)x, Type = x.ToString() })
                                             .ToArray();


                    foreach (var transmission in transmissions)
                    {
                         context.Transmissions.Add(transmission);
                    }

                    await context.SaveChangesAsync();
               }
          }
          public static async Task SeedFuel(CarRentAppDbContext context)
          {
               if (!context.Fuel.Any())
               {
                    var fuels = Enum.GetValues(typeof(FuelEnum))
                                             .OfType<FuelEnum>()
                                             .Select(x => new Fuel() { Id = (int)x, Type = x.ToString() })
                                             .ToArray();


                    foreach (var fuel in fuels)
                    {
                         context.Fuel.Add(fuel);
                    }

                    await context.SaveChangesAsync();
               }
          }


          public static async Task SeedCarBody(CarRentAppDbContext context)
          {
               if (!context.CarBody.Any())
               {
                    var carBodies = Enum.GetValues(typeof(CarBodyEnum))
                                             .OfType<CarBodyEnum>()
                                             .Select(x => new CarBody() { Id = (int)x, Type = x.ToString() })
                                             .ToArray();


                    foreach (var carBody in carBodies)
                    {
                         context.CarBody.Add(carBody);
                    }

                    await context.SaveChangesAsync();
               }
          }
     }
}
