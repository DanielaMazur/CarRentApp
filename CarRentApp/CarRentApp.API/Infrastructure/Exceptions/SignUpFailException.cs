using System.Net;

namespace CarRentApp.API.Infrastructure.Exceptions
{
     public class SignUpFailException : ApiException
     {
          public SignUpFailException(string message) : base(HttpStatusCode.BadRequest, message)
          {

          }
     }
}
