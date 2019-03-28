using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

   public static class Errors
   {
      public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
      {
         foreach (var e in identityResult.Errors)
         {
            modelState.TryAddModelError(e.Code, e.Description);
         }
         return modelState;
      }

      public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
      {
         modelState.TryAddModelError(code, description);
         return modelState;
      }
   }
}
