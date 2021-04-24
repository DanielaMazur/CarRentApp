﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarRentApp.API.Infrastructure.Extensions
{
     public static class HostExtensions
     {
          public static async Task SeedData(this IHost host)
          {
               using (var scope = host.Services.CreateScope())
               {
                    var services = scope.ServiceProvider;
                    try
                    {
                         var context = services.GetRequiredService<CarRentAppDbContext>();

                         context.Database.Migrate();

                         await Seed.SeedCars(context);
                         await Seed.SeedPhotos(context);

                    }
                    catch (Exception ex)
                    {
                         var logger = services.GetRequiredService<ILogger<Program>>();
                         logger.LogError(ex, "An error occured during migration");
                    }
               }
          }
     }
}