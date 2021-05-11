using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRentApp.API.Dtos.Account;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.API.Infrastructure.Exceptions;
using AutoMapper;

namespace CarRentApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class AccountController : ControllerBase
     {
          public readonly IAccountService _accountService;
          private readonly IMapper _mapper;

          public AccountController(IAccountService accountService, IMapper mapper)
          {
               _accountService = accountService;
               _mapper = mapper;
          }

          [AllowAnonymous]
          [ApiExceptionFilter]
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

          [AllowAnonymous]
          [ApiExceptionFilter]
          [HttpPost("register")]
          public async Task<IActionResult> Register(AccountLoginDto userForLoginDto)
          {
               await _accountService.SignUp(userForLoginDto);

               return Ok();
          }

          [Authorize]
          [HttpGet]
          public IActionResult GetAccount()
          {
               var account = _accountService.GetUserWithRole();

               var accountDto = _mapper.Map<AccountDto>(account);

               return Ok(accountDto);
          }

          [Authorize]
          [ApiExceptionFilter]
          [HttpPost("clients")]
          public async Task<IActionResult> PostClient(CreateClientDto client)
          {
               await _accountService.AddClient(client);

               return Ok();
          }
     }
}
