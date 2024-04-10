using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class OtherInfo : BaseEntity
    {
        public string Title { get; set; }
        public virtual List<OtherInfoDescription> OtherInfoDescriptions { get; set; }
    }
}
