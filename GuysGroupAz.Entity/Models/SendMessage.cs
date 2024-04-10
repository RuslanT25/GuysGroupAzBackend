using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class SendMessage : BaseEntity
    {
        public string FullName { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
