using System;

namespace Mandrillus.Contracts.Validators
{
   public interface IValidator<T>
   {
      bool IsValid(T entity);
   }
}
