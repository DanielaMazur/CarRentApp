using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.API.Infrastructure.Exceptions;
using AutoMapper;
using CarRentApp.API.Models.User;

namespace CarRentApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class UserController : ControllerBase
     {
          public readonly IUserService _userService;
          private readonly IMapper _mapper;

          public UserController(IUserService userService, IMapper mapper)
          {
               _userService = userService;
               _mapper = mapper;
          }

          [AllowAnonymous]
          [ApiExceptionFilter]
          [HttpPost("login")]
          public async Task<IActionResult> Login(UserLoginModel userForLoginDto)
          {
               var accessToken = await _userService.Login(userForLoginDto);

               if (accessToken == null)
               {
                    return Unauthorized();
               }

               return Ok(new { AccessToken = accessToken });
          }

          [AllowAnonymous]
          [ApiExceptionFilter]
          [HttpPost("register")]
          public async Task<IActionResult> Register(UserRegistrerModel userModel)
          {
               await _userService.SignUp(userModel);

               return Ok();
          }

          [Authorize]
          [HttpGet]
          public IActionResult GetAccount()
          {
               var account = _userService.GetUserWithRole();

               var accountDto = _mapper.Map<UserModel>(account);

               return Ok(accountDto);
          }
     }
}
