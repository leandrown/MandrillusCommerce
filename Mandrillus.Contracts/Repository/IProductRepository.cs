using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Contracts.Repository
{
   public interface IProductRepository
   {
      Task<bool> AddProduct(Product product);
      Task<Product> GetProduct(int id);
      Task<bool> RemoveProduct(int id);
      Task<ICollection<Product>> GetAllProducts();
   }
}
