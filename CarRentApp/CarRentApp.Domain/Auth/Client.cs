using System.Collections.Generic;

namespace CarRentApp.Domain.Auth
{
     public class Client : User
     {
          public long IDNP { get; set; }
          public string DriverLicenseId { get; set; }
          public ICollection<Reservation> Reservations { get; set; }
     }
}
