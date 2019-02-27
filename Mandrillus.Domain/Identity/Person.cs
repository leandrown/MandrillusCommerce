using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mandrillus.Domain.Identity
{
   public class Person : IdentityUser
   {
      public string FName { get; set; }
      public string SName { get; set; }
   }
}
