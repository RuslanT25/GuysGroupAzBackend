using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Service
{
    public class ServicePostDTO 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int>? QuestionIds { get; set; }
    }
}
