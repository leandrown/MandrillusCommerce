using System.Threading.Tasks;
using Mandrillus.Contracts.Factories;
using Mandrillus.Contracts.Handlers;
using Mandrillus.Contracts.Repository;
using Mandrillus.Contracts.Validators;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Logics.Managers
{
   public class PeopleManager : IPersonRepository
   {
      private IEntityFactory<Person> _factory;
      private IValidator<Person> _validator;
      private IExceptionHandler _handler;

      public PeopleManager(IEntityFactory<Person> factory, IValidator<Person> validator, IExceptionHandler handler)
      {
         _factory = factory;
         _validator = validator;
         _handler = handler;
      }

      public async Task<bool> AddPersonAsync(Person person)
      {
         if (_validator.IsValid(person))
            return _handler != null && await _handler.Run(() => _factory.CreateAsync(person));
         return false;
      }

      public Task<bool> RemovePersonAsync(string personId)
      {
         throw new System.NotImplementedException();
      }
   }
}
