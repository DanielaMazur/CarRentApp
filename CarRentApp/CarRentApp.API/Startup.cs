using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.API.Services;
using CarRentApp.API.Infrastructure.Extensions;
using CarRentApp.Domain.Auth;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using CarRentApp.Domain.EFMapping.Repositories.Interfaces;
using CarRentApp.Domain.EFMapping.Repositories;
using CarRentApp.Domain.EFMapping;

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

               services.AddControllers(options =>
               {
                    options.Filters.Add(new AuthorizeFilter());
               });

               services.AddIdentity<User, Role>(options =>
               {
                    options.Password.RequiredLength = 8;
               })
               .AddEntityFrameworkStores<CarRentAppDbContext>().AddDefaultTokenProviders();

               var authOptions = services.ConfigureAuthOptions(Configuration);
               services.AddJwtAuthentication(authOptions);

               services.AddScoped<IReservationRepository, ReservationsRepository>();
               services.AddScoped<IFuelRepository, FuelRepository>();
               services.AddScoped<ICarBodyRepository, CarBodyRepository>();
               services.AddScoped<ITransmissionRepository, TransmissionRepository>();
               services.AddScoped<ICarRepository, CarRepository>();

               services.AddScoped<IUserService, UserService>();
               services.AddScoped<ICarService, CarService>();
               services.AddScoped<ICarFiltersService, CarFiltersService>();
               services.AddScoped<IReservationService, ReservationService>();
               services.AddAutoMapper(Assembly.GetExecutingAssembly());
               services.AddHttpContextAccessor();
               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                         Version = "v1",
                         Title = "API",
                    });
                    var securitySchema = new OpenApiSecurityScheme
                    {
                         Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                         Name = "Authorization",
                         In = ParameterLocation.Header,
                         Type = SecuritySchemeType.Http,
                         Scheme = "bearer",
                         Reference = new OpenApiReference
                         {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                         }
                    };
                    c.AddSecurityDefinition("Bearer", securitySchema);

                    var securityRequirement = new OpenApiSecurityRequirement();
                    securityRequirement.Add(securitySchema, new[] { "Bearer" });
                    c.AddSecurityRequirement(securityRequirement);
               });
          }


          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();

                    app.UseSwagger();

                    app.UseSwaggerUI(c =>
                    {
                         c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentApp V1");
                         c.RoutePrefix = string.Empty;
                    });
               }

               app.UseHttpsRedirection();

               app.UseStaticFiles();

               app.UseRouting();

               app.UseAuthentication();

               app.UseAuthorization();

               app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
