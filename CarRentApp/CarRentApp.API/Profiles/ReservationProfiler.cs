using AutoMapper;
using CarRentApp.API.Models.Reservation;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class ReservationProfiler : Profile
     {
          public ReservationProfiler()
          {
               CreateMap<Reservation, ReservationModel>();
          }
     }
}
