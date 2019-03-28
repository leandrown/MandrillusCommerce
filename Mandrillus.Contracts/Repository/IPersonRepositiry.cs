using System.Threading.Tasks;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Contracts.Repository
{
   public interface IPersonRepositiry
   {
      Task<bool> AddPersonAsync(Person person);
      Task<bool> RemovePersonAsync(string personId);
   }
}
