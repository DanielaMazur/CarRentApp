using System.Reflection;
using CarRentApp.API.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CarRentApp.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.API.Services;
using CarRentApp.API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using CarRentApp.Domain.Auth;

namespace CarRentApp.API
{
     public class Startup
     {
          public Startup(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          public IConfiguration Configuration { get; }

          // This method gets called by the runtime. Use this method to add services to the container.
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddDbContext<CarRentAppDbContext>(optionBuilder =>
               {
                    optionBuilder.UseSqlServer(Configuration.GetConnectionString("CarRentConnection"));
               });

               var authOptions = services.ConfigureAuthOptions(Configuration);
               services.AddJwtAuthentication(authOptions);

               services.AddControllers();

               services.AddIdentity<User, Role>(options =>
               {
                    options.Password.RequiredLength = 8;
               })
               .AddEntityFrameworkStores<CarRentAppDbContext>();

               services.AddScoped<IAccountService, AccountService>();
               services.AddScoped<IRepository, EFCoreRepository>();
               services.AddScoped<ICarService, CarService>();
               services.AddAutoMapper(Assembly.GetExecutingAssembly());
               services.AddSwaggerGen();
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }

               app.UseSwagger();

               app.UseSwaggerUI(c =>
               {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
               });

               app.UseHttpsRedirection();

               app.UseStaticFiles();

               app.UseRouting();

               app.UseAuthorization();

               app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
