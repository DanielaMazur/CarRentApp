using System.Threading.Tasks;
using CarRentApp.API.Dtos.Account;
using CarRentApp.Domain.Auth;

namespace CarRentApp.API.Services.Interfaces
{
     public interface IAccountService
     {
          Task<string> Login(AccountLoginDto userForLoginDto);
          Task SignUp(AccountLoginDto userForLoginDto);
          AccountDto GetUserWithRole();
          Task AddClient(CreateClientDto clientDto);
     }
}
