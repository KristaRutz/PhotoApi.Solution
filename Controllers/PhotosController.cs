using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhotoApi.Models;

namespace PhotoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PhotosController : ControllerBase
  {
    private PhotoApiContext _db;

    public PhotosController(PhotoApiContext db)
    {
      _db = db;
    }

    // GET api/photos
    [HttpGet]
    public ActionResult<IEnumerable<Photo>> Get()
    {
      return _db.Photos.ToList();
    }

    // POST api/photos
    [HttpPost]
    public void Post([FromBody] Photo photo)
    {
      _db.Photos.Add(photo);
      _db.SaveChanges();
    }
  }
}