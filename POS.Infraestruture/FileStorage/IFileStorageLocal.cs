using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.FileStorage
{
    public interface IFileStorageLocal
    {
        Task<string> SaveFile(string container, IFormFile file, string webRootPath, string scheme, string host);
        Task<string> EditFile(string container, IFormFile file, string route, string webRootPath, string scheme, string host);
        Task RemoveFile(string route, string container, string webRootPath);
    }
}
