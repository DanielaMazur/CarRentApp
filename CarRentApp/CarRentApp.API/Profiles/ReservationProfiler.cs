using AutoMapper;
using CarRentApp.API.Dtos.Reservation;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class ReservationProfiler : Profile
     {
          public ReservationProfiler()
          {
               CreateMap<Reservation, ReservationDto>();
          }
     }
}
