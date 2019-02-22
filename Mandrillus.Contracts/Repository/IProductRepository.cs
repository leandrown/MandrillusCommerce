using System.Collections.Generic;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Contracts.Repository
{
   public interface IProductRepository
   {
      bool AddProduct(Product product);
      Product GetProduct(int id);
      bool RemoveProduct(int id);
      ICollection<Product> GetAllProducts();
   }
}
