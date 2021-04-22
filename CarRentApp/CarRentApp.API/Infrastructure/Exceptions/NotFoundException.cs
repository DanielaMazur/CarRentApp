using System.Net;

namespace CarRentApp.API.Infrastructure.Exceptions
{
     public class NotFoundException : ApiException
     {
          public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
          {

          }
     }
}
