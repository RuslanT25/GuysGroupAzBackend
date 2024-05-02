using GuysGroupAz.Entity.DTOs.BlogImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Blog
{
    public class BlogGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public virtual List<BlogImageGetDTO> BlogImages { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
