using System;
using Mandrillus.Contracts.Validators;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Logics.Validators
{
   public class ProductValidator : IValidator<Product>
   {
      public bool IsValid(Product entity)
      {
         return (!string.IsNullOrEmpty(entity.Name)) && entity.Price > 0 && (!string.IsNullOrEmpty(entity.Description));
      }
   }
}
