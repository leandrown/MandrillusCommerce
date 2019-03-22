using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Mandrillus.Contracts.Factories;
using Mandrillus.Domain.Configurations.Auth;

namespace Mandrillus.Logics.Factories
{
   public class TokenFactory : ITokenFactory
   {
      private readonly JwtIssuerOptions _issuerOptions;

      public TokenFactory(JwtIssuerOptions issuerOptions)
      {
         _issuerOptions = issuerOptions;
         ThrowInvalidOptions(_issuerOptions);
      }

      private void ThrowInvalidOptions(JwtIssuerOptions issuerOptions)
      {
         if (issuerOptions == null) throw new ArgumentNullException(nameof(issuerOptions));
         if (issuerOptions.ValidUntil <= TimeSpan.Zero) throw new ArgumentNullException($"Token expiration must be greater than zero");
         if (issuerOptions.SinSigningCredentials == null) throw new ArgumentNullException(nameof(issuerOptions.SinSigningCredentials));
         if (issuerOptions.JtiGenerator == null) throw new ArgumentNullException(nameof(issuerOptions.JtiGenerator));
      }

      private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

      public Task<string> GenerateIdentityToken(string username, ClaimsIdentity identity)
      {
         throw new System.NotImplementedException();
      }

      public ClaimsIdentity GenerateUserIdentity(string username, string id)
      {
         throw new System.NotImplementedException();
      }
   }
}
