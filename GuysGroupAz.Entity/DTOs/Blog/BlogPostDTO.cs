using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Blog
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImageFile { get; set; }
        public List<int> BlogImageIds { get; set; }
        public DateTime PublishDate { get; set; }
    }
}