using AutoMapper;
using CarRentApp.API.Dtos.CarFilters;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class CarFiltersProfiler : Profile
     {
          public CarFiltersProfiler()
          {
               CreateMap<Transmission, TransmissionDto>();
               CreateMap<Fuel, FuelDto>();
               CreateMap<CarBody, CarBodyDto>();
               CreateMap<CarFilters, CarFiltersDto>();
          }
     }
}
