using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    [RegularExpression(@"^#[\w|_|\-|#]+",
      ErrorMessage = "A list of alphanumeric words (hyphens or dashes ok) separated by hashtags: e.g. '#a#tag#like#this#123#half-time#ice_cream' ")]
    public string Hashtags { get; set; }
  }
}