using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Mandrillus.Contracts.Factories;
using Mandrillus.Domain.Configurations.Auth;
using Mandrillus.Extensions.Constants;
using System.Security.Principal;

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
         if (issuerOptions.SigningCredentials == null) throw new ArgumentNullException(nameof(issuerOptions.SigningCredentials));
         if (issuerOptions.JtiGenerator == null) throw new ArgumentNullException(nameof(issuerOptions.JtiGenerator));
      }

      private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

      public async Task<string> GenerateIdentityToken(string username, ClaimsIdentity identity)
      {
         Claim[] claims = {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, await _issuerOptions.JtiGenerator()),
            new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_issuerOptions.IssueDate).ToString(), ClaimValueTypes.Integer64),
            identity.FindFirst(ClaimsIdentifiers.Rol),
            identity.FindFirst(ClaimsIdentifiers.Id)
         };

         JwtSecurityToken jwt = new JwtSecurityToken(_issuerOptions.Issuer, _issuerOptions.Audience, claims, _issuerOptions.NotBefore, _issuerOptions.Expiration, _issuerOptions.SigningCredentials);

         string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
         return encodedJwt;
      }

      public ClaimsIdentity GenerateUserIdentity(string username, string id)
      {
         return new ClaimsIdentity(new GenericIdentity(username, "Token"), new[]
         {
            new Claim(ClaimsIdentifiers.Id, id),
            new Claim(ClaimsIdentifiers.Rol,JwtClaims.ApiAccess)
         });
      }
   }
}
