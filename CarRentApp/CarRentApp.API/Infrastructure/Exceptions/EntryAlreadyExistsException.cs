using System.Net;

namespace CarRentApp.API.Infrastructure.Exceptions
{
     public class EntryAlreadyExistsException : ApiException
     {
          public EntryAlreadyExistsException(string message) : base(HttpStatusCode.BadRequest, message)
          {

          }
     }
}
