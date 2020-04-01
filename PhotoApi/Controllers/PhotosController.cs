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
    public ActionResult<IEnumerable<Photo>> Get(string title, string tag, string url, string userName, int page, int size)
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

      //////////// PAGINATION
      int maxPageSize = 100;
      int pageSize = 20; //defaults to 20 items per page

      int pageNumber = (page > 0) ? page : 1; //defaults to page 1
      if (size > 0)
      {
        pageSize = (size > maxPageSize) ? maxPageSize : size;
      }

      return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    // GET api/photos/count
    [HttpGet("count")]
    public ActionResult<int> CountPhotos(string title, string tag, string url, string userName)
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

      return query.ToList().Count();
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