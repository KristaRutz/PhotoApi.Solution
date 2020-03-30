using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public ActionResult<IEnumerable<Photo>> Get(string title, string tag, string url)
    {
      List<Photo> query = new List<Photo>() { };

      if (tag != null)
      {
        // 1. Use the string tag to identify associated TagId, if any.
        var thisTag = _db.Tags.FirstOrDefault(t => t.Name == tag);
        var thisTagId = thisTag.TagId;

        // Find all joins with tagId
        var joinsWithTag = _db.PhotoTag.Where(join => join.TagId == thisTagId);

        // Make list of all PhotoIds from that list of joins
        List<int> listOfPhotoIds = new List<int>() { };
        foreach (var join in joinsWithTag)
        {
          listOfPhotoIds.Add(join.PhotoId);
        }

        // Make list of all photos from that list of photoIds
        foreach (int photoId in listOfPhotoIds)
        {
          // get specific photo associated with id using db calls
          Photo thisPhoto = _db.Photos.FirstOrDefault(p => p.PhotoId == photoId);
          query.Add(thisPhoto);
        }
        query = query.AsQueryable();
      }
      else
      {
        query = _db.Photos.AsQueryable();
      }

      // https://dotnettutorials.net/lesson/inner-join-in-linq/

      if (title != null)
      {
        query = query.Where(photo => photo.Title == title);
      }

      if (url != null)
      {
        query = query.Where(photo => photo.Url == url);
      }

      return query.ToList();
    }

    // -----------------------

    // POST api/photos
    [HttpPost]
    public void Post([FromBody] Photo photo)
    {
      _db.Photos.Add(photo);
      _db.SaveChanges();
    }

    // GET api/photos/5
    [HttpGet("{id}")]
    public ActionResult<Photo> Get(int id)
    {
      return _db.Photos.FirstOrDefault(entry => entry.PhotoId == id);
    }

    // PUT api/photos/8
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Photo photo)
    {
      photo.PhotoId = id;
      _db.Entry(photo).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // Delete api/photos/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var photoToDelete = _db.Photos.FirstOrDefault(entry => entry.PhotoId == id);
      _db.Photos.Remove(photoToDelete);
      _db.SaveChanges();
    }
  }
}