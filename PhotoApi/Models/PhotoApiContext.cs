using Microsoft.EntityFrameworkCore;

namespace PhotoApi.Models
{
  public class PhotoApiContext : DbContext
  {
    public PhotoApiContext(DbContextOptions<PhotoApiContext> options) : base(options) { }

    public DbSet<Photo> Photos { get; set; }
  }
}