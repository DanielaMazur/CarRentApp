using AutoMapper;
using CarRentApp.API.Dtos.Cars;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class CarProfile : Profile
     {
          public CarProfile()
          {
               CreateMap<Car, CarDto>();
          }
     }
}
