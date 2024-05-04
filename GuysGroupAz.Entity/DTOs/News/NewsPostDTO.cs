using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.News
{
    public class NewsPostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImageFile { get; set; }
        public List<int> NewsImageIds { get; set; }
        public DateTime PublishDate { get; set; }
    }
}