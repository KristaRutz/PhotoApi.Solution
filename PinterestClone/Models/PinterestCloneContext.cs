using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PinterestClone.Models
{
  public class PinterestCloneContext : IdentityDbContext<ApplicationUser>
  {
    public PinterestCloneContext(DbContextOptions options) : base(options) { }
  }
}