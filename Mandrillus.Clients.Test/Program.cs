using System;
using System.Net.Http;

namespace Mandrillus.Clients.Test
{
   public class ProductViewModel
   {
      public int ProductId { get; set; }
      public DateTime DateCreated { get; set; }
      public string ShortDescription { get; set; }
      public bool IsDownloadable { get; set; }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Press enter to continue...");
         Console.ReadLine();

         using (HttpClient client = new HttpClient())
         {
            HttpResponseMessage products = client.GetAsync("").Result;
         }
      }
   }
}
