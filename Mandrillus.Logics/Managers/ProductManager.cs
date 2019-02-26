using System.Collections.Generic;
using Mandrillus.Contracts.Factories;
using Mandrillus.Contracts.Handlers;
using Mandrillus.Contracts.Repository;
using Mandrillus.Contracts.Validators;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Logics.Managers
{
   public class ProductManager : IProductRepository
   {
      private IEntityFactory<Product> _factory;
      private IValidator<Product> _validator;
      private IExceptionHandler _handler;

      public ProductManager(IEntityFactory<Product> factory, IValidator<Product> validator, IExceptionHandler handler)
      {
         _factory = factory;
         _validator = validator;
         _handler = handler;
      }

      public bool AddProduct(Product product)
      {
         if (_validator.IsValid(product))
            return _handler.Run(() => _factory.CreateAsync(product).Result);
         return false;
      }

      public ICollection<Product> GetAllProducts()
      {
         return _handler.Run(() => _factory.GetAllAsync().Result);
      }

      public Product GetProduct(int id)
      {
         throw new System.NotImplementedException();
      }

      public bool RemoveProduct(int id)
      {
         throw new System.NotImplementedException();
      }
   }
}
