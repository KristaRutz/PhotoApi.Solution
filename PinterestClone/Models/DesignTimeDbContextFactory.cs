using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PinterestClone.Models
{
  public class PinterestCloneContextFactory : IDesignTimeDbContextFactory<PinterestCloneContext>
  {

    PinterestCloneContext IDesignTimeDbContextFactory<PinterestCloneContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PinterestCloneContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PinterestCloneContext(builder.Options);
    }
  }
}