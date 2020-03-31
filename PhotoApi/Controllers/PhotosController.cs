using System;
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
    public ActionResult<IEnumerable<Photo>> Get(string title, string tag, string url, string userName)
    {
      var query = _db.Photos.AsQueryable();

      if (tag != null)
      {
        query = query.Where(photo => photo.SearchForTag(tag) == true);
      }

      if (title != null)
      {
        query = query.Where(entry => entry.Title == title);
      }

      if (url != null)
      {
        query = query.Where(entry => entry.Url == url);
      }

      if (userName != null)
      {
        query = query.Where(entry => entry.UserName == userName);
      }

      return query.ToList();
    }

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
      var photoToUpdate = _db.Photos.FirstOrDefault(entry => entry.PhotoId == id);
      if (photo.UserName == photoToUpdate.UserName)
      {
        photo.PhotoId = id;
        _db.Entry(photo).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }

    // Delete api/photos/5
    [HttpDelete("{id}")]
    public void Delete(int id, [FromBody] string userName)
    {
      var photoToDelete = _db.Photos.FirstOrDefault(entry => entry.PhotoId == id);
      if (userName == photoToDelete.UserName)
      {
        _db.Photos.Remove(photoToDelete);
        _db.SaveChanges();
      }
    }
  }
}