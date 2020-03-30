using System.Collections.Generic;

namespace PhotoApi.Models
{
  public class Photo
  {
    public int PhotoId { get; set; }

    [StringLength(100)]
    [Required]
    public string Title { get; set; }

    [StringLength(255)]
    [Required]
    public string Url { get; set; }

    [StringLength(100)]
    [Required]
    public string UserName { get; set; }

    [StringLength(100)]
    public string Tag { get; set; }

    // public ICollection<PhotoTag> Tags { get; set; }

    // public Photo()
    // {
    //   this.Tags = new HashSet<PhotoTag>();
    // }
  }
}