using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage {  get; set; }
        public virtual List<NewsImage> NewsImages { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
