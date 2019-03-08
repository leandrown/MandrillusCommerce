using System;
using Mandrillus.Domain.Entities.BaseModels;

namespace Mandrillus.Domain.Entities.Catalog
{
   public class Product : BaseEntity
   {
      public string Name { get; set; }
      public double Price { get; set; }
      public string Description { get; set; }

      //public int ProductId { get; set; }
      //public DateTime DateCreated { get; set; }
      //public string ShortDescription { get; set; }
      //public bool IsDownloadable { get; set; }
   }
}
