using System;
using Microsoft.AspNetCore.Http;

namespace Mandrillus.Business.Api.Extensions
{
   public static class ResponseExtension
   {
      public static void AddApplicationError(this HttpResponse response, string message)
      {
         response.Headers.Add("Application Error", message);
         response.Headers.Add("access-control-expose-headers", "Application-Error");
      }
   }
}
