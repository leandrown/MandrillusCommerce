using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Mandrillus.Business.Api.Models
{
   public class RegisterViewModel
   {
      [Required, JsonProperty("fname")]
      public string FName { get; set; }
      [Required, JsonProperty("sname")]
      public string SName { get; set; }
      [Required, JsonProperty("password")]
      public string Password { get; set; }
      [Required, JsonProperty("confirmpassword")]
      [DataType(DataType.Password)]
      public string ConfirmPassword { get; set; }
      [Required, DataType(DataType.EmailAddress), JsonProperty("email")]
      public string Email { get; set; }
   }
   public class LoginViewModel
   {
      [Required, DataType(DataType.EmailAddress), JsonProperty("username")]
      public string UserName { get; set; }
      [Required, DataType(DataType.Password), JsonProperty("password")]
      public string Password { get; set; }
   }
}
