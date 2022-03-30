using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace Tasnim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        public VideosController()
        {
        }
        [HttpPost]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> UploadVideoFiles(IList<IFormFile> files)
        {
            string path = Path.Combine("wwwroot/AppData/Videos");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);

                if (file.Length > 0 && fileName.EndsWith(".mp4"))
                {
                    using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                else
                {
                    return BadRequest("Only mp4 files are allowed");
                }
            }
            return Ok();
        }
        
        [HttpGet]
        public async Task<FileContentResult> GetVideo(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AppData/Videos", fileName);

            var file = await System.IO.File.ReadAllBytesAsync(path);

            return File(file, "application/octet-stream", fileName);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteVideo(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AppData/Videos", fileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            else
            {
                return BadRequest("File not found");
            }

            return Ok();
        }
    }
}
