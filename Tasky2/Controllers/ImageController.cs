using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasky2.Repository;

namespace Tasky2.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageRepository _imageRepository;
        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public IActionResult Index()
        {
            var imagedProcessed = _imageRepository.Process();

            return View("Index", imagedProcessed);
        }
    }
}