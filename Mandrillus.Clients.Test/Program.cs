using System;
using System.Linq;
using System.Net.Http;

namespace Mandrillus.Clients.Test
{
   public class ProductViewModel
   {
      public string Name { get; set; }
      public int Price { get; set; }
      public string Description { get; set; }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Press enter to continue...");
         Console.ReadLine();

         using (HttpClient client = new HttpClient())
         {
            HttpResponseMessage results = client.GetAsync("http://localhost:5000/api/values").Result;

            if (results.IsSuccessStatusCode)
            {
               string[] values = results.Content.ReadAsAsync<string[]>().Result;
               values.ToList().ForEach(v => { Console.WriteLine($"value =: {v}"); });
            }
            Console.ReadLine();
         }
      }
   }
}
