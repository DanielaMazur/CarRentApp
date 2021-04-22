using System;
using System.Net;

namespace CarRentApp.API.Infrastructure.Exceptions
{
     public class ApiException : Exception
     {
          public HttpStatusCode Code { get; set; }
          public ApiException()
          {

          }

          public ApiException(HttpStatusCode code, string message) : base(message)
          {
               Code = code;
          }
     }
}
