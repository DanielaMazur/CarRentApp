using System.Threading.Tasks;
using CarRentApp.API.Models.User;

namespace CarRentApp.API.Services.Interfaces
{
     public interface IUserService
     {
          Task<string> Login(UserLoginModel userForLoginDto);
          Task SignUp(UserRegistrerModel userForLoginDto);
          UserModel GetUserWithRole();
     }
}
