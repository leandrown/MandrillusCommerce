using System;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Domain.Domains.Customers
{
   public class Customer : Person
   {
      public bool IsActive { get; set; }
      public DateTime AddedOn { get; set; }
      public bool HasShoppingCartItems { get; set; }
      public bool Deleted { get; set; }
   }
}
