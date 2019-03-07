using Mandrillus.Contracts.Validators;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Logics.Validators
{
   public class ProductValidator : IValidator<Product>
   {
      public bool IsValid(Product entity)
      {
         return (entity.ProductId >= 0 && (!string.IsNullOrEmpty(entity.ShortDescription)));
      }
   }
}
