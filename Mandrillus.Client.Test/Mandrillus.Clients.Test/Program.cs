using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Mandrillus.Clients.Test
{
   public class ProductViewModel
   {
      public string Name { get; set; }
      public double Price { get; set; }
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
            // Anonymous types:
            var person = new
            {
               fname = "Leandro",
               sname = "Vieira",
               password = "vieira2019",
               confirmpassword = "vieira2019",
               email = "leandrown@outlook.com"
            };
            string jObj = JsonConvert.SerializeObject(person);
            HttpContent content = new StringContent(jObj, Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PostAsync("http://localhost:5000/api/accounts/register", content).Result;
            if (result.IsSuccessStatusCode)
            {
               string reMessage = result.Content.ReadAsStringAsync().Result;
               Console.WriteLine(reMessage);
            }
         }
         Console.ReadLine();
      }
   }
}