using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Mandrillus.Contracts.Factories;
using Mandrillus.Domain.Configurations.Auth;

namespace Mandrillus.Business.Api.Extensions
{
   public static class TokenExtension
   {
      public static async Task<string> GenerateJwtTokenAsync(ClaimsIdentity identity, ITokenFactory factory, string username, JwtIssuerOptions options, JsonSerializerSettings serializerSettings)
      {
         var token = new
         {
            id = identity.Claims.Single(s => s.Type == "id").Value,
            token = await factory.GenerateIdentityToken(username, identity),
            expiration = (int)options.ValidUntil.TotalSeconds
         };
         return JsonConvert.SerializeObject(token, serializerSettings);
      }
   }
}
