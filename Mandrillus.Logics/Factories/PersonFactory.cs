using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrillus.Contracts.Factories;
using Mandrillus.Data.Contexts;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Logics.Factories
{
   public class PersonFactory : IEntityFactory<Person>
   {
      private MandrillusDbContext _db;
      public PersonFactory(MandrillusDbContext db)
      {
         _db = db;
      }

      public async Task<bool> CreateAsync(Person entity)
      {
         if (entity == null)
            throw new ArgumentNullException(nameof(entity));
         await _db.Users.AddAsync(entity);
         await _db.SaveChangesAsync();
         return true;
      }

      public Task<ICollection<Person>> GetAllAsync()
      {
         throw new System.NotImplementedException();
      }

      public Task<Person> GetAsync(int id)
      {
         throw new System.NotImplementedException();
      }

      public Task<bool> RemoveAsync(int id)
      {
         throw new System.NotImplementedException();
      }
   }
}
