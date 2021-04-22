using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentApp.Domain;
using CarRentApp.Domain.Auth;
using Microsoft.AspNetCore.Identity;

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
                        Fuel = Domain.Enums.Fuel.Diesel,
                        Transmission = Domain.Enums.Transmission.Mecanic,
                        Body = Domain.Enums.CarBody.Sedan,
                        FabricationYear = new System.DateTime(2015, 1, 1),
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
                         Fuel = Domain.Enums.Fuel.Gasoline,
                         Transmission = Domain.Enums.Transmission.Mecanic,
                         Body = Domain.Enums.CarBody.Sedan,
                         FabricationYear = new System.DateTime(2017, 1, 1),
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
                         Fuel = Domain.Enums.Fuel.Gasoline,
                         Transmission = Domain.Enums.Transmission.Automatic,
                         Body = Domain.Enums.CarBody.Sedan,
                         FabricationYear = new System.DateTime(2016, 1, 1),
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
                         new Photo { Path = "Cars/2017_mercedes_benz_c_class_angularfront.jpg", CarId = 2 },
                         new Photo { Path = "Cars/2017_mercedes_benz_c_class_dashboard.jpg", CarId = 2 },
                         new Photo { Path = "Cars/2017_mercedes_benz_c_class_trunk.jpg", CarId = 2 },
                         new Photo { Path = "Cars/2015_Toyota_Corolla_15.jpg", CarId = 1 },
                         new Photo { Path = "Cars/2015_toyota_corolla_angularfront.jpg", CarId = 1 },
                         new Photo { Path = "Cars/2015_toyota_corolla_trunk.jpg", CarId = 1 },
                         new Photo { Path = "Cars/2016_bmw_5_series_angularfront.jpg", CarId = 3 },
                         new Photo { Path = "Cars/2016_bmw_5_series_dashboard.jpg", CarId = 3 },
                         new Photo { Path = "Cars/2016_bmw_5_series_trunk.jpg", CarId = 3 }
                    };

                    foreach(var photo in photos)
                    {
                         context.Photos.Add(photo);
                    }

                    await context.SaveChangesAsync();
               }
          }

          public static async Task SeedCarReservations(CarRentAppDbContext context)
          {
               if (!context.Clients.Any())
               {
                    //var manning = new CarReservation()
                    //{
                    //     Name = "Manning Publications"
                    //};

                    //context.Clients.Add(manning);
                    //context.Clients.Add(microsoftPress);
                    //context.Clients.Add(apress);
                    //context.Clients.Add(oReillyMedia);
                    //context.Clients.Add(packtPublishing);

                    await context.SaveChangesAsync();
               }
          }

          public static async Task SeedReservations(CarRentAppDbContext context)
          {
               if (!context.Clients.Any())
               {
                    //var manning = new Reservation()
                    //{
                    //     Name = "Manning Publications"
                    //};

                    //context.Clients.Add(manning);
                    //context.Clients.Add(microsoftPress);
                    //context.Clients.Add(apress);
                    //context.Clients.Add(oReillyMedia);
                    //context.Clients.Add(packtPublishing);

                    await context.SaveChangesAsync();
               }
          }

          public static async Task SeedUsers(UserManager<Client> userManager)
          {
               if (!userManager.Users.Any())
               {
                    var user = new Client()
                    {
                         UserName = "admin",
                         Email = "admin@onlinebookshop.com",
                    };

                    await userManager.CreateAsync(user, "Qwerty1!");
               }
          }
     }
}
