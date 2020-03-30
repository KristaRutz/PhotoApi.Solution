using Microsoft.EntityFrameworkCore;

namespace PhotoApi.Models
{
  public class PhotoApiContext : DbContext
  {
    public PhotoApiContext(DbContextOptions<PhotoApiContext> options) : base(options) { }

    public virtual DbSet<Photo> Photos { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public DbSet<PhotoTag> PhotoTag { get; set; }
  }
}