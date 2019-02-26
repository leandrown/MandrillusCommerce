using System;
using System.Threading.Tasks;
using Mandrillus.Domain.Entities.BaseModels;
using Mandrillus.Domain.Entities.Catalog;
using System.Collections.Generic;

namespace Mandrillus.Contracts.Factories
{
   public interface IEntityFactory<T> where T : BaseEntity
   {
      Task<bool> CreateAsync(T entity);
      Task<T> GetAsync(int id);
      Task<bool> RemoveAsync(int id);
      Task<ICollection<T>> GetAllAsync();
   }
}
