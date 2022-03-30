using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Tasnim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImageFiles(IList<IFormFile> files)
        {
            string path = Path.Combine("wwwroot/AppData/Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);

                if (file.Length > 0 && 
                    fileName.EndsWith(".jpg") || 
                    fileName.EndsWith(".png") ||
                    fileName.EndsWith(".jpeg"))
                {
                    using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                else
                {
                    return BadRequest("Only image files are allowed");
                }
            }
            return Ok();
        }
        
        [HttpGet]
        public async Task<MemoryStream> GetImage(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AppData/Images", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return memory;

            //return File(System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AppData/Images", fileName)), "application/octet-stream", fileName);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AppData/Images", fileName);

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
