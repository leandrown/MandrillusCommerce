﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mandrillus.Business.Api.Extensions;
using Mandrillus.Business.Api.Models;
using Mandrillus.Contracts.Repository;
using Mandrillus.Domain.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mandrillus.Business.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AccountsController : ControllerBase
   {
      private UserManager<Person> _userManager;

      public AccountsController(UserManager<Person> userManager)
      {
         _userManager = userManager;
      }

      [HttpPost, Route("Register")]
      public async Task<IActionResult> Register(RegisterViewModel model)
      {
         if (!ModelState.IsValid && model.Password != model.ConfirmPassword)
            return BadRequest(ModelState);
         Person userIdentity = new Person
         {
            UserName = model.Email,
            Email = model.Email,
            FName = model.FName,
            SName = model.SName
         };
         IdentityResult result = await _userManager.CreateAsync(userIdentity, model.Password);
         if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
         return new OkObjectResult("New person added successfully!");
      }
   }
}