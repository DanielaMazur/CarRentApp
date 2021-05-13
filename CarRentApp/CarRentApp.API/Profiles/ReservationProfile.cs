using AutoMapper;
using CarRentApp.API.Models.Reservation;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class ReservationProfile : Profile
     {
          public ReservationProfile()
          {
               CreateMap<Reservation, ReservationModel>();
          }
     }
}
