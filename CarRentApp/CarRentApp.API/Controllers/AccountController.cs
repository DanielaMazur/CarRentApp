using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRentApp.API.Dtos.Account;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.API.Infrastructure.Exceptions;

namespace CarRentApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class AccountController : ControllerBase
     {
          public readonly IAccountService _accountService;

          public AccountController(IAccountService accountService)
          {
               _accountService = accountService;
          }

          [AllowAnonymous]
          [HttpPost("login")]
          public async Task<IActionResult> Login(AccountLoginDto userForLoginDto)
          {
               var accessToken = await _accountService.Login(userForLoginDto);

               if (accessToken == null)
               {
                    return Unauthorized();
               }

               return Ok(new { AccessToken = accessToken });
          }

          [ApiExceptionFilter]
          [HttpPost("register")]
          public async Task<IActionResult> Register(AccountLoginDto userForLoginDto)
          {
               var accessToken = await _accountService.SignUp(userForLoginDto);

               return Ok(new { AccessToken = accessToken });
          }
     }
}
