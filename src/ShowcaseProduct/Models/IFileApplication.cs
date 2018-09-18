using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public interface IFileApplication
    {
        void UploadFile(IFormFile file);
    }
}
