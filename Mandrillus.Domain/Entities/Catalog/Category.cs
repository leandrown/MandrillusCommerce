using Mandrillus.Domain.Entities.BaseModels;

namespace Mandrillus.Domain.Entities.Catalog
{
   public class Category : BaseEntity
   {
      public int? PatentId { get; set; }
      public string CatName { get; set; }
   }
}
