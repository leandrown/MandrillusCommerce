using System;
using Mandrillus.Domain.Entities.BaseModels;

namespace Mandrillus.Domain.Entities.Media
{
   public class Image : BaseEntity
   {
      public string MimeType { get; set; }
      public string ImageName { get; set; }
      public int ImageSize { get; set; }
      public ImageBinary ImageBinary { get; set; }
   }

   public class ImageBinary : BaseEntity
   {
      public byte[] ImageBytes { get; set; }
      public Image Image { get; set; }
   }
}
