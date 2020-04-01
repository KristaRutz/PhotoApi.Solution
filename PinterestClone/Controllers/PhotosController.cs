using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PinterestClone.Models;

namespace PinterestClone.Controllers
{
  public class PhotosController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public PhotosController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index(int id = 1)
    {
      string size = "5";
      string page = $"{id}";

      var allPhotos = Photo.GetPhotos(null, null, null, null, size, page);

      ViewBag.Size = int.Parse(size);
      ViewBag.Page = int.Parse(page);
      ViewBag.PhotoCount = Photo.GetCount(null, null, null, null);

      return View(allPhotos);
    }

    //[HttpGet("/index/{page}")]
    // [Http("page/{page}")]
    // public IActionResult Page(int page)
    // {
    //   string size = "20";
    //   string pageStr = $"{page}";

    //   var allPhotos = Photo.GetPhotos(null, null, null, null, size, "2");

    //   ViewBag.Size = int.Parse(size);
    //   ViewBag.Page = 2;

    //   ViewBag.PhotoCount = Photo.GetCount(null, null, null, null);

    //   return View();
    // }

    // localhost:5000/photos/{id}
    public IActionResult Details(int id)
    {
      var thisPhoto = Photo.GetDetails(id);
      return View(thisPhoto);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Photo photo)
    {
      Photo.Post(photo);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var thisPhoto = Photo.GetDetails(id);
      return View(thisPhoto);
    }

    [HttpPost]
    public IActionResult Edit(Photo photo)
    {
      Photo.Put(photo);
      return RedirectToAction("Details", new { id = photo.PhotoId });
    }

    public IActionResult Delete(int id)
    {
      var thisPhoto = Photo.GetDetails(id);
      return View(thisPhoto);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Photo.Delete(id);
      return RedirectToAction("Index");
    }
  }
}