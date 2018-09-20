using Microsoft.AspNetCore.Http;
using ShowcaseProduct.Models.ConstApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class FileApplication : IFileApplication
    {
        public async void UploadFile(IFormFile file)
        {
            Utils utils = new Utils();
            var path = Path.Combine(Directory.GetCurrentDirectory(), AllConstants.PathFolderImage) + '\\' + utils.GetValueWithIndexAfterSplit('\\', 1, file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
