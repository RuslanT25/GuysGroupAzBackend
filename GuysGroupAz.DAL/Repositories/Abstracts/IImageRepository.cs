using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Abstracts
{
    public interface IImageRepository
    {
        public Task<string> ImageUpload(string folder, IFormFile file);
        public void DeleteImage(string folder, string file);
    }
}
