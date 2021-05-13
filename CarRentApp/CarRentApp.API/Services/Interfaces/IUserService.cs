using System.Threading.Tasks;
using CarRentApp.API.Models.Account;

namespace CarRentApp.API.Services.Interfaces
{
     public interface IUserService
     {
          Task<string> Login(AccountLoginModel userForLoginDto);
          Task SignUp(AccountLoginModel userForLoginDto);
          AccountModel GetUserWithRole();
     }
}
