
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mandrillus.Contracts.Factories;
using Mandrillus.Contracts.Handlers;
using Mandrillus.Contracts.Repository;
using Mandrillus.Contracts.Validators;
using Mandrillus.Data.Contexts;
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
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
         services.AddCors(option =>
         {
            option.AddPolicy("AllowOrigin", builder => builder.WithOrigins(""));
         });
         services.AddDbContext<MandrillusDbContext>();
         services.AddIdentity<Person, Role>().AddEntityFrameworkStores<MandrillusDbContext>();
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

         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseMvc();
         app.UseCors("AllowOrigin");
      }
   }
}
