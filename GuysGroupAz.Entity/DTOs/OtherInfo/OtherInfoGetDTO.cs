using GuysGroupAz.Entity.DTOs.OtherInfoDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.OtherInfo
{
    public class OtherInfoGetDTO
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public virtual List<OtherInfoDescriptionGetDTO>? OtherInfoDescriptions { get; set; }
    }
}