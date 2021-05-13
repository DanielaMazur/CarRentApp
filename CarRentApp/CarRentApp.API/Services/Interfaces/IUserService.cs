using System.Threading.Tasks;
using CarRentApp.API.Dtos.Account;

namespace CarRentApp.API.Services.Interfaces
{
     public interface IUserService
     {
          Task<string> Login(AccountLoginDto userForLoginDto);
          Task SignUp(AccountLoginDto userForLoginDto);
          AccountDto GetUserWithRole();
     }
}
