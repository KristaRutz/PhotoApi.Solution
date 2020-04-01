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

    public IActionResult Index()
    {
      var allPhotos = Photo.GetPhotos();
      return View(allPhotos);
    }

    // public IActionResult Index(int page)
    // {
    //   // Overload of index where it's passed a page number
    //   var allPhotos = Photo.GetPhotos(page);
    //   ViewBag.PageNumber = page;
    //   return View(allPhotos);
    // }

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