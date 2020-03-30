using System.Collections.Generic;

namespace PhotoApi.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    public string Name { get; set; }
    public ICollection<PhotoTag> Photos { get; set; }

    public Tag()
    {
      this.Photos = new HashSet<PhotoTag>();
    }
  }
}