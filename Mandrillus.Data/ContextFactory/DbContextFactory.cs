using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Mandrillus.Data.Contexts;

namespace Mandrillus.Data.ContextFactory
{
   public class DbContextFactory : IDesignTimeDbContextFactory<MandrillusDbContext>
   {
      public MandrillusDbContext CreateDbContext(string[] args)
      {
         var builder = new DbContextOptionsBuilder<MandrillusDbContext>();
         // See MandrillusDbContext.cs to learn more
         //string connection = @"DataSource=localhost; Initial Catalog=MandrillusCommerceDB; Integrated Security=True; Pooling=False";

         string connection = @"Server=tcp:localhost; Database=MandrillusCommerceDB; User ID=sa; Password=m1n3cr@wl3r; MultipleActiveResultSets=True";
         builder.UseSqlServer(connection, builderOption => builderOption.MigrationsAssembly(typeof(MandrillusDbContext).GetTypeInfo().Assembly.GetName().Name));
         return new MandrillusDbContext(builder.Options);
      }
   }
}
