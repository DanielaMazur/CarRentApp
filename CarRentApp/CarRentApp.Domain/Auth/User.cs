using Microsoft.AspNetCore.Identity;

namespace CarRentApp.Domain.Auth
{
     public class User : IdentityUser<int>
     {
          public string FirstName {get; set;}
          public string LastName { get; set; }
     }
}
