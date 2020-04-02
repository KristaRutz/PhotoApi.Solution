using Microsoft.EntityFrameworkCore;

namespace PinterestClone.Models
{
  public class PinterestCloneContext : DbContext
  {
    public DbSet<ApplicationUser> Users { get; set; }

    public PinterestCloneContext(DbContextOptions options) : base(options) { }
  }
}