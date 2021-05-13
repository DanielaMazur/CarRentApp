using AutoMapper;
using CarRentApp.API.Models.User;
using CarRentApp.Domain.Auth;

namespace CarRentApp.API.Profiles
{
     public class UserProfile : Profile
     {
          public UserProfile()
          {
               CreateMap<User, UserLoginModel>();
               CreateMap<User, UserRegistrerModel>();
               CreateMap<User, UserModel>();
          }
     }
}
