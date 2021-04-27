using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarRentApp.API.Infrastructure.Exceptions
{
     public class SignUpFailException : ApiException
     {
          public SignUpFailException(string message) : base(HttpStatusCode.BadRequest, message)
          {

          }
     }
}
