using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasky2.Repository;

namespace Tasky2.Controllers
{
    [Route("api")]
    [ApiController, Authorize]
    public class ImageApiController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        public ImageApiController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet("image/process")]
        public IActionResult GetProcessedImage()
        {
            var images = _imageRepository.Process();

            return Ok(images);
        }
    }
}