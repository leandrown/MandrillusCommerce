using System.Security.Claims;
using System.Threading.Tasks;

namespace Mandrillus.Contracts.Factories
{
   public interface ITokenFactory
   {
      Task<string> GenerateIdentityToken(string username, ClaimsIdentity identity);
      ClaimsIdentity GenerateUserIdentity(string username, string id);
   }
}
