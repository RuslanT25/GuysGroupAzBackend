using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<AboutImage> AboutImages { get; set; }
    }
}