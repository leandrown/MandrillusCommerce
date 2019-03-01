using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mandrillus.Contracts.Repository;
using Mandrillus.Data.Contexts;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Web.Client.Controllers
{
   public class ProductsController : Controller
   {
      private IProductRepository _repository;

      public ProductsController(IProductRepository repository)
      {
         _repository = repository;
      }

      // GET: Products
      //public async Task<IActionResult> Index()
      //{
      //   return View(await Task<ICollection<Product>>.Factory.StartNew(() => _repository.GetAllProducts()));
      //}

      // GET: Products/Create
      public IActionResult Create()
      {
         return View();
      }

      //[HttpPost]
      //[ValidateAntiForgeryToken]

      //public async Task<IActionResult> Create([Bind("Name, Price, Description")] Product product)
      //{
      //   if (ModelState.IsValid)
      //   {
      //      if (await Task<bool>.Factory.StartNew(() => _repository.AddProduct(product)))
      //         return RedirectToAction(nameof(Index));
      //   }
      //   return View(product);
      //}
   }
}
