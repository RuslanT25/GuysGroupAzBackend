using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Question>? Questions { get; set; }
    }
}