﻿using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Mandrillus.Domain.Configurations.Auth
{
   public class JwtIssuerOptions
   {
      public string Issuer { get; set; }
      public string Subject { get; set; }
      public string Audience { get; set; }
      public DateTime Expiration => IssueDate.Add(ValidUntil);
      public DateTime IssueDate => DateTime.UtcNow;
      public TimeSpan ValidUntil { get; set; } = TimeSpan.FromMinutes(120);

      public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());
      public SigningCredentials SigningCredentials { get; set; }
      public DateTime? NotBefore { get; set; }
   }
}
