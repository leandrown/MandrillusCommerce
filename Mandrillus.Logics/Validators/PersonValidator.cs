using Mandrillus.Contracts.Validators;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Logics.Validators
{
   public class PersonValidator : IValidator<Person>
   {
      public bool IsValid(Person entity)
      {
         return (entity.Email != null && entity.UserName != null && entity.FName != null && entity.SName != null);
      }
   }
}
