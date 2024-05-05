using GuysGroupAz.Entity.DTOs.Teacher;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Course
{
    public class CourseGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TeachingMethod { get; set; }
        public string DescriptionForTeachingMethod { get; set; }
        public virtual List<TeacherGetDTO>? Teachers { get; set; }
    }
}