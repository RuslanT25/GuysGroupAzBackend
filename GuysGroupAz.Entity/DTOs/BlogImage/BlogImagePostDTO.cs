using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.BlogImage
{
    public class BlogImagePostDTO
    {
        public string Name { get; set; }
        public IFormFile ImageFile {  get; set; } 
    }
}