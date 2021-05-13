using AutoMapper;
using CarRentApp.API.Models.Photo;
using CarRentApp.Domain;

namespace CarRentApp.API.Profiles
{
     public class PhotoProfile : Profile
     {
          public PhotoProfile()
          {
               CreateMap<Photo, PhotoModel>();
          }
     }
}
