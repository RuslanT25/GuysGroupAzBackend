using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class OtherInfoDescription : BaseEntity
    {
        public string Description { get; set; }
        public virtual OtherInfo OtherInfo { get; set; }
        public int OtherInfoId { get; set; }
    }
}
