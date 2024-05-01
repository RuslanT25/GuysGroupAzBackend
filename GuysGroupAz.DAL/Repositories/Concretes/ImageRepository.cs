using GuysGroupAz.DAL.Repositories.Abstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Concretes
{
    public class ImageRepository : IImageRepository
    {
        readonly IWebHostEnvironment _env;
        public ImageRepository(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }
        public void DeleteImage(string folder, string file)
        {
            string fullPath = Path.Combine(_env.WebRootPath, "uploads\\photos", folder, file);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
        public async Task<string> ImageUpload(string folder, IFormFile file)
        {
            string folderPath = Path.Combine(_env.WebRootPath, "uploads\\photos", folder);
            string filePath = Guid.NewGuid() + "_" + file.FileName;
            string fullPath = Path.Combine(folderPath, filePath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream stream = new(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
