using System;
using System.Collections.Generic;

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
            HttpResponseMessage results = client.GetAsync("http://localhost:5000/api/products").Result;

            if (results.IsSuccessStatusCode)
            {
               //string[] values = results.Content.ReadAsAsync<string[]>().Result;
               var values = results.Content.ReadAsAsync<IEnumerable<ProductViewModel>>().Result;
               values.ToList().ForEach(v => { Console.WriteLine($"value =: {v.Name} Price: {v.Price}"); });
            }
            Console.ReadLine();
         }
      }
   }
}