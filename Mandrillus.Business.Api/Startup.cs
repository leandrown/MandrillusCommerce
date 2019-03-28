using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Mandrillus.Contracts.Factories;
using Mandrillus.Contracts.Handlers;
using Mandrillus.Contracts.Repository;
using Mandrillus.Contracts.Validators;
using Mandrillus.Data.Contexts;
using Mandrillus.Domain.Configurations.Auth;
using Mandrillus.Domain.Entities.Catalog;
using Mandrillus.Domain.Identity;
using Mandrillus.Logics.Factories;
using Mandrillus.Logics.Handlers;
using Mandrillus.Logics.Managers;
using Mandrillus.Logics.Validators;

namespace Mandrillus.Business.Api
{
   public class Startup
   {
      private const string SecretKey = "s0mBr3R0";
      private readonly SymmetricSecurityKey _signkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

         services.AddDbContext<MandrillusDbContext>();
         services.AddIdentity<Person, Role>(p =>
         {
            p.Password.RequireDigit = false;
            p.Password.RequireLowercase = false;
            p.Password.RequireUppercase = false;
            p.Password.RequireNonAlphanumeric = false;
            p.Password.RequiredLength = 6;
         }).AddEntityFrameworkStores<MandrillusDbContext>().AddDefaultTokenProviders();

         services.AddSingleton<ITokenFactory, TokenFactory>();
         services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
         JwtIssuerOptions jwtIssuerOptions = new JwtIssuerOptions
         {
            Issuer = "webApi",
            Audience = "localhost:5000",
            SigningCredentials = new SigningCredentials(_signkey, SecurityAlgorithms.HmacSha256)
         };
         TokenValidationParameters tokenValidationParameter = new TokenValidationParameters
         {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuerOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtIssuerOptions.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _signkey,

            RequireExpirationTime = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
         };
         services.AddAuthentication(option =>
         {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         }).AddJwtBearer(configOption =>
         {
            configOption.ClaimsIssuer = jwtIssuerOptions.Issuer;
            configOption.TokenValidationParameters = tokenValidationParameter;
            configOption.SaveToken = true;
         });

         services.AddTransient<ILogger, Logger>();
         services.AddTransient<IValidator<Product>, ProductValidator>();
         services.AddTransient<IExceptionHandler, ExceptionHandler>();
         services.AddTransient<IEntityFactory<Product>, ProductFactory>();
         services.AddTransient<IProductRepository, ProductManager>();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }

         app.UseExceptionHandler(builder =>
         {
            builder.Run(async context =>
            {
               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
               context.Response.Headers.Add("access-control-Allow-Origin", "*");

               var error = context.Features.Get<IExceptionHandlerFeature>();
            });
         });
         // app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseMvc();
         app.UseCors("AllowOrigin");
      }
   }
}
