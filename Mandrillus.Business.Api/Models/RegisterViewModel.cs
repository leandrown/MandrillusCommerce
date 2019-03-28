using System;
using System.ComponentModel.DataAnnotations;


namespace Mandrillus.Business.Api.Models
{
   public class RegisterViewModel
   {
      [Required]
      public string FName { get; set; }
      [Required]
      public string SName { get; set; }
      [Required]
      public string Password { get; set; }
      [Required]
      [DataType(DataType.Password)]
      public string ConfirmPassword { get; set; }
      [Required, DataType(DataType.EmailAddress)]
      public string Email { get; set; }
   }
}
