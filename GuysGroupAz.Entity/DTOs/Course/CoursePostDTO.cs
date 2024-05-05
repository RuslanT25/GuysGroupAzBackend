using GuysGroupAz.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Course
{
    public class CoursePostDTO
    {
        public string Name { get; set; }
        public TypeOfCourse Type { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        public string TeachingMethod { get; set; }
        public string DescriptionForTeachingMethod { get; set; }
        public virtual List<int>? TeacherIds { get; set; }
    }
}