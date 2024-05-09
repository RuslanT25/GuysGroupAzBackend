using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.OtherInfo
{
    public class OtherInfoPostDTO
    {
        public string Title { get; set; }
        public virtual List<int>? OtherInfoDescriptionIds { get; set; }
    }
}