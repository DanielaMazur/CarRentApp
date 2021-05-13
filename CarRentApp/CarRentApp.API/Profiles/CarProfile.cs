using AutoMapper;
using CarRentApp.API.Models.Car;
using CarRentApp.Domain;
using CarRentApp.Domain.Enums;
using System;

namespace CarRentApp.API.Profiles
{
     public class CarProfile : Profile
     {
          public CarProfile()
          {
               CreateMap<Car, CarModel>()
                    .ForMember(destination => destination.Transmission,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(TransmissionEnum), source.TransmissionId)))
                    .ForMember(destination => destination.Fuel,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(FuelEnum), source.FuelId)))
                    .ForMember(destination => destination.Body,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(CarBodyEnum), source.CarBodyId)));
               CreateMap<Car, CarPreviewModel>();
          }
     }
}

