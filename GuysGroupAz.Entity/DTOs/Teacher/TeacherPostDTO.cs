using GuysGroupAz.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.DTOs.Teacher
{
    public class TeacherPostDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Profession { get; set; }
        public IFormFile ImageFile { get; set; }
        public int? CourseId { get; set; }
    }
}