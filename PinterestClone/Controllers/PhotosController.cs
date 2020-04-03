using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PinterestClone.Models;
using PinterestClone.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace PinterestClone.Controllers
{
  [Authorize]
  public class PhotosController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public PhotosController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [AllowAnonymous]
    public IActionResult Index(int id = 1)
    {
      string size = "25";
      string page = $"{id}";

      var allPhotos = Photo.GetPhotos(null, null, null, null, size, page);

      ViewBag.Size = int.Parse(size);
      ViewBag.Page = id;
      ViewBag.PhotoCount = Photo.GetCount(null, null, null, null);

      return View(allPhotos);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Search(SearchViewModel search, int id = 1)
    {
      string size = "5";
      string page = $"{id}";

      var allPhotos = Photo.GetPhotos(null, search.Tag, null, null, size, page);

      ViewBag.Size = int.Parse(size);
      ViewBag.Page = id;
      ViewBag.PhotoCount = Photo.GetCount(null, search.Tag, null, null);
      ViewBag.Tag = search.Tag;
      ViewBag.Search = search;
      return View(allPhotos);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Search(string tag)
    {
      SearchViewModel search = new SearchViewModel
      {
        Tag = tag
      };
      return RedirectToAction("Search", search);
    }

    [AllowAnonymous]
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