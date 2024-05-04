using GuysGroupAz.Entity.DTOs.BlogImage;
using GuysGroupAz.Entity.DTOs.NewsImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.News
{
    public class NewsGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public virtual List<NewsImageGetDTO> NewsImages { get; set; }
        public DateTime PublishDate { get; set; }
    }
}