using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class Contact : BaseEntity
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
