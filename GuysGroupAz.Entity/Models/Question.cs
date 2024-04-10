using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class Question : BaseEntity
    {
        public string Topic { get; set; }
        public string Issue { get; set; }
        public string Answer { get; set; }
    }
}
