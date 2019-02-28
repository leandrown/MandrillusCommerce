using System;

namespace Mandrillus.Domain.Configurations
{
   public class Setting
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Value { get; set; }

      public Setting(int id, string name, string value)
      {
         Id = id;
         Name = name;
         Value = value;
      }
   }
}
