using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.OtherInfoDescription
{
    public class OtherInfoDescriptionGetDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string OtherInfo { get; set; }
    }
}