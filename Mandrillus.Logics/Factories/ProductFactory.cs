using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mandrillus.Contracts.Factories;
using Mandrillus.Data.Contexts;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Logics.Factories
{
   public class ProductFactory : IEntityFactory<Product>
   {
      private MandrillusDbContext _db;

      public ProductFactory(MandrillusDbContext db)
      {
         _db = db;
      }

      public async Task<bool> CreateAsync(Product entity)
      {
         if (entity == null)
            throw new ArgumentNullException(nameof(entity));
         return await Task<bool>.Factory.StartNew(() =>
         {
            _db.Products.AddAsync(entity);
            _db.SaveChangesAsync();
            return true;
         });
      }

      public Task<Product> GetAsync(int id)
      {
         throw new NotImplementedException();
      }

      public async Task<ICollection<Product>> GetAllAsync()
      {
         if (!await _db.Products.AnyAsync())
            return null;
         return await _db.Products.ToListAsync();
      }

      public Task<bool> RemoveAsync(int id)
      {
         throw new NotImplementedException();
      }
   }
}
