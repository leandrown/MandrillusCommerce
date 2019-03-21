using System.Security.Claims;
using System.Threading.Tasks;
using Mandrillus.Contracts.Factories;

namespace Mandrillus.Logics.Factories
{
   public class TokenFactory : ITokenFactory
   {
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
