using System;
using Microsoft.EntityFrameworkCore;
using Mandrillus.Domain.Entities.Catalog;

namespace Mandrillus.Data.Contexts
{
   public class MandrillusDbContext : DbContext
   {
      public MandrillusDbContext(DbContextOptions<MandrillusDbContext> builder)
         : base(builder) { }

      public DbSet<Product> Products { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         string connection = @"DataSource=localhost; Initial Catalog=MandrillusCommerceDB; Integrated Security=True; Pooling=False";
         optionsBuilder.UseSqlServer(connection);
      }
   }
}
