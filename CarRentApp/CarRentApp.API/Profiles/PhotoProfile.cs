using AutoMapper;
using CarRentApp.API.Dtos.Photo;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class PhotoProfile : Profile
     {
          public PhotoProfile()
          {
               CreateMap<Photo, PhotoDto>();
          }
     }
}
