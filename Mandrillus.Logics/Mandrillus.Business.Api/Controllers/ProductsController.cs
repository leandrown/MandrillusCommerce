using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mandrillus.Contracts.Repository;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Business.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProductsController : ControllerBase
   {
      private readonly IProductRepository _repository;

      public ProductsController(IProductRepository repository)
      {
         _repository = repository;
      }

      public async Task<IEnumerable<Product>> Get()
      {
         return await _repository.GetAllProducts();
      }
   }
}
