using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using CarRentApp.API.Dtos.Account;
using CarRentApp.API.Infrastructure.Configurations;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CarRentApp.API.Services
{
     public class AccountService : IAccountService
     {
          private readonly AuthOptions _authenticationOptions;
          private readonly SignInManager<User> _signInManager;
          private UserManager<User> _userManager;
          private IRepository _repository;

          public AccountService(IOptions<AuthOptions> authenticationOptions, SignInManager<User> signInManager, UserManager<User> userManager, IRepository repository)
          {
               _authenticationOptions = authenticationOptions.Value;
               _signInManager = signInManager;
               _userManager = userManager;
               _repository = repository;
          }

          public async Task<string> Login(AccountLoginDto userForLoginDto)
          {
               var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userForLoginDto.Email, userForLoginDto.Password, false, false);

               if (checkingPasswordResult.Succeeded)
               {
                    var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                         issuer: _authenticationOptions.Issuer,
                         audience: _authenticationOptions.Audience,
                         claims: new List<Claim>(),
                         expires: DateTime.Now.AddDays(30),
                         signingCredentials: signinCredentials
                    );

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                    return encodedToken;
               }

               return null;
          }

          public async Task<string> SignUp(AccountLoginDto userForLoginDto)
          {
               var user = new User { Email = userForLoginDto.Email, UserName = userForLoginDto.Email };
               var result = await _userManager.CreateAsync(user, userForLoginDto.Password);

               if (result.Succeeded)
               {
                    return await Login(userForLoginDto);
               }

               foreach (var error in result.Errors)
               {
                    throw new SignUpFailException(error.Description);
               }

               throw new SignUpFailException("Signup faild!");
          }
     }
}
