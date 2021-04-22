using CarRentApp.API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CarRentApp.API
{
     public class Program
     {
          public static async System.Threading.Tasks.Task Main(string[] args)
          {
               IHost host = CreateHostBuilder(args).Build();

               await host.SeedData();
               await host.RunAsync();
          }

          public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                       webBuilder.UseStartup<Startup>();
                  });
     }
}
