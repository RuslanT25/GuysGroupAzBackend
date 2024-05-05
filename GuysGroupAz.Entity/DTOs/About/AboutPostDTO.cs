using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.About
{
    public class AboutPostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> AboutImageIds { get; set; }
    }
}