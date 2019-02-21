using System;
using Mandrillus.Domain.Entities.BaseModels;

namespace Mandrillus.Domain.Entities.Catalog
{
   public class Product : BaseEntity
   {
      public string Name { get; set; }
      public double Price { get; set; }
      public string Description { get; set; }
   }
}
