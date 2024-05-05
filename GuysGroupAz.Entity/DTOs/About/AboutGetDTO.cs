using GuysGroupAz.Entity.DTOs.AboutImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.About
{
    public class AboutGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AboutImageGetDTO> AboutImages { get; set; }
    }
}