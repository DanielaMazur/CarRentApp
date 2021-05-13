using AutoMapper;
using CarRentApp.API.Models.CarFilters;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class CarFiltersProfile : Profile
     {
          public CarFiltersProfile()
          {
               CreateMap<Transmission, TransmissionModel>();
               CreateMap<Fuel, FuelModel>();
               CreateMap<CarBody, CarBodyModel>();
               CreateMap<CarFilters, CarFiltersModel>();
          }
     }
}
