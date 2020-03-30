using System.Collections.Generic;

namespace PhotoApi.Models
{
  public class Photo
  {
    public int PhotoId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }

    public ICollection<PhotoTag> Tags { get; set; }

    public Photo()
    {
      this.Tags = new HashSet<PhotoTag>();
    }
  }
}