using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mandrillus.Contracts.Repository;
using Mandrillus.Domain.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mandrillus.Business.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AccountsController : ControllerBase
   {
      private IPersonRepository _repository;
      private UserManager<Person> _userManager;

      public AccountsController(IPersonRepository repository, UserManager<Person> userManager)
      {
         _repository = repository;
         _userManager = userManager;
      }

      public async Task<IActionResult> Register()
      {

      }
   }
}
