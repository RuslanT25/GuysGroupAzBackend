using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Profession { get; set; }
        public string Image {  get; set; }
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
