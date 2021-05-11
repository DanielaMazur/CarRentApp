using System.Net;

namespace CarRentApp.API.Infrastructure.Exceptions
{
     public class InvalidInputException : ApiException
     {
          public InvalidInputException(string message) : base(HttpStatusCode.BadRequest, message)
          {

          }
     }
}
