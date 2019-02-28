using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mandrillus.Domain.Entities.Catalog;
using Mandrillus.Domain.Identity;

namespace Mandrillus.Data.Contexts
{
   public class MandrillusDbContext : IdentityDbContext<Person, Role, string>
   {
      public MandrillusDbContext(DbContextOptions<MandrillusDbContext> builder)
         : base(builder) { }

      public DbSet<Product> Products { get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         base.OnModelCreating(builder);
         builder.Entity<Person>().ToTable("People").Property(p => p.Id).HasColumnName("PersonId");
         builder.Entity<Role>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");
         builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
         builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
         builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimId");
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         // Use DataSource to create a local database on Windows or a SQLite database on Mac.
         // If you want to test more options, see the docs: https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-2.2&tabs=visual-studio-mac
         // To enable Kerberos auth: https://github.com/dotnet/corefx/issues/22184
         // Docker: https://github.com/dotnet/dotnet-docker-samples/issues/89
         // Migrations: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-2.0#introduction-to-migrations

         //string connection = @"DataSource=localhost; Initial Catalog=MandrillusCommerceDB; Integrated Security=True; Pooling=False";
         string connection = @"Server=tcp:localhost; Database=MandrillusCommerceDB; User ID=sa; Password=m1n3cr@wl3r; MultipleActiveResultSets=True";
         optionsBuilder.UseSqlServer(connection);
      }
   }
}
