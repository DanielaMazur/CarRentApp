﻿using CarRentApp.Domain.Intefaces;
using Microsoft.AspNetCore.Identity;

namespace CarRentApp.Domain.Auth
{
     public class User : IdentityUser<int>, IEntity
     {
     }
}
