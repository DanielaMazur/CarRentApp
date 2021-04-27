﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CarRentApp.API.Infrastructure.Configurations
{
     public class AuthOptions
     {
          public string SecretKey { get; set; }
          public string Issuer { get; set; }
          public string Audience { get; set; }
          public int TokenLifetime { get; set; }

          public SymmetricSecurityKey GetSymmetricSecurityKey()
          {
               return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
          }

     }
}
