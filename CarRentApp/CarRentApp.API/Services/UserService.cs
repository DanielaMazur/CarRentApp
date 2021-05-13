using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarRentApp.API.Dtos.Account;
using CarRentApp.API.Infrastructure.Configurations;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;
using CarRentApp.Domain.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CarRentApp.API.Services
{
     public class UserService : IUserService
     {
          private readonly AuthOptions _authenticationOptions;
          private readonly UserManager<User> _userManager;
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly SignInManager<User> _signInManager;

          public UserService(IOptions<AuthOptions> authenticationOptions, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
          {
               _authenticationOptions = authenticationOptions.Value;
               _userManager = userManager;
               _httpContextAccessor = httpContextAccessor;
               _signInManager = signInManager;
          }

          public async Task<string> Login(AccountLoginDto userData)
          {
               var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userData.Email, userData.Password, false, false);

               if (checkingPasswordResult.Succeeded)
               {
                    var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);

                    var user = await _userManager.FindByEmailAsync(userData.Email);

                    if (user == null)
                    {
                         throw new NotFoundException("A user with such Id was not found!");
                    }

                    var userClaims = await _userManager.GetClaimsAsync(user);

                    var loginClaims = new[] {
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, userData.Email),
                   };

                    var jwtSecurityToken = new JwtSecurityToken(
                         issuer: _authenticationOptions.Issuer,
                         audience: _authenticationOptions.Audience,
                         claims: loginClaims.Concat(userClaims).ToArray(),
                         expires: DateTime.Now.AddDays(30),
                         signingCredentials: signinCredentials
                    );

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                    return encodedToken;
               }

               return null;
          }

          public async Task SignUp(AccountLoginDto userForLoginDto)
          {
               var user = new User { Email = userForLoginDto.Email, UserName = userForLoginDto.Email };
               var result = await _userManager.CreateAsync(user, userForLoginDto.Password);

               if (result.Succeeded)
               {
                    await _userManager.AddClaimsAsync(user, new Claim[] { new Claim(ClaimTypes.Role, "Client"), new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) });
                    return;
               }

               foreach (var error in result.Errors)
               {
                    throw new SignUpFailException(error.Description);
               }

               throw new SignUpFailException("Signup faild!");
          }

          public AccountDto GetUserWithRole()
          {
               var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
               var role = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

               return new AccountDto() { Email = email, Role = role };
          }
     }
}
