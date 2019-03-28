using System.Threading.Tasks;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Contracts.Repository
{
   public interface IPersonRepository
   {
      Task<bool> AddPersonAsync(Person person);
      Task<bool> RemovePersonAsync(string personId);
   }
}
