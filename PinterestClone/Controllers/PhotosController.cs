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

    public IActionResult Details(int id)
    {
      var thisPhoto = Photo.GetDetails(id);
      return View(thisPhoto);
    }
  }
}