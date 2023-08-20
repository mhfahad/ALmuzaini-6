using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AlmuzainiCMS.Models.Utility
{
    public static class FileManagement
    {
        public static string UploadImageFile(IFormFile file, string directory, IHttpContextAccessor _httpContextAccessor)
        {
            try
            {
                var permitedExtensions = new List<string>
                {
                    ".jpeg", ".jpg", ".png"
                };
                //var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (permitedExtensions.Contains(extension))
                {
                    string fileName = Guid.NewGuid() + "_" + DateTime.Now.Ticks + "_" + file.FileName;

                    var serverFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + directory);
                    var imageUrl = Path.Combine(directory, fileName);

                    if (!Directory.Exists(serverFolder))
                    {
                        Directory.CreateDirectory(serverFolder);
                    }
                    var path = Path.Combine(serverFolder, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return imageUrl;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
