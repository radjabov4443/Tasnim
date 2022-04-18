using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim.Service.Helpers;

namespace Tasnim.Service.Extensions
{
    public static class SaveFile
    {
        public static async Task<(string, string)> SaveFileAsync(this Stream file, string fileName, IConfiguration config, string webRootPath)
        {
            string hostUrl = HttpContextHelper.Context?.Request?.Scheme + "://" + HttpContextHelper.Context?.Request?.Host.Value;


            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;

            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(webRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);

            string webUrl = $@"{hostUrl}/{storagePath}/{fileName}";


            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return (fileName, webUrl);
        }
    }
}
