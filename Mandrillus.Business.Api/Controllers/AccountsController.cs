using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Mandrillus.Business.Api.Extensions;
using Mandrillus.Business.Api.Models;
using Mandrillus.Contracts.Factories;
using Mandrillus.Contracts.Repository;
using Mandrillus.Domain.Configurations.Auth;
using Mandrillus.Domain.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mandrillus.Business.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AccountsController : ControllerBase
   {
      private readonly UserManager<Person> _userManager;
      private readonly ITokenFactory _tokenFactory;
      private readonly JwtIssuerOptions _options;

      public AccountsController(UserManager<Person> userManager, ITokenFactory tokenFactory, JwtIssuerOptions options)
      {
         _userManager = userManager;
         _tokenFactory = tokenFactory;
         _options = options;
      }

      [HttpPost, Route("Login")]
      public async Task<IActionResult> Login([FromBody]LoginViewModel model)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }
         ClaimsIdentity user = await GetClaimsIdentity(model.UserName, model.Password);
         if (user == null)
            return BadRequest(Errors.AddErrorToModelState("login_failure", "invalid password or username", ModelState));
         string token = await TokenExtension.GenerateJwtTokenAsync(user, _tokenFactory, model.UserName, _options, new JsonSerializerSettings { Formatting = Formatting.Indented });
         return new OkObjectResult(token);
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

      public async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
      {
         if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            return await Task.FromResult<ClaimsIdentity>(null);
         Person user = await _userManager.FindByNameAsync(username);
         if (user == null)
            return await Task.FromResult<ClaimsIdentity>(null);
         if (await _userManager.CheckPasswordAsync(user, password))
            return await Task.FromResult(_tokenFactory.GenerateUserIdentity(username, user.Id));
         return await Task.FromResult<ClaimsIdentity>(null);
      }
   }
}
