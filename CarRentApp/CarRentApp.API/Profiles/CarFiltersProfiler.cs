using AutoMapper;
using CarRentApp.API.Models.CarFilters;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class CarFiltersProfiler : Profile
     {
          public CarFiltersProfiler()
          {
               CreateMap<Transmission, TransmissionModel>();
               CreateMap<Fuel, FuelModel>();
               CreateMap<CarBody, CarBodyModel>();
               CreateMap<CarFilters, CarFiltersModel>();
          }
     }
}
