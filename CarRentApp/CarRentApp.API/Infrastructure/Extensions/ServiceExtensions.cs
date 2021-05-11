using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CarRentApp.API.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CarRentApp.API.Infrastructure.Extensions
{
     public static class ServiceExtensions
     {
          public static void AddJwtAuthentication(this IServiceCollection services, AuthOptions authOptions)
          {
               services.AddAuthentication(options =>
               {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               }).AddJwtBearer(options =>
               {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                         ValidateIssuer = true,
                         ValidIssuer = authOptions.Issuer,

                         ValidateAudience = true,
                         ValidAudience = authOptions.Audience,

                         ValidateLifetime = true,

                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    };
               }).AddCookie();
          }

          public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
          {
               var authOptionsConfigurationSection = configuration.GetSection("AuthOptions");
               services.Configure<AuthOptions>(authOptionsConfigurationSection);
               var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
               return authOptions;
          }
     }
}