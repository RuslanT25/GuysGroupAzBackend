using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Entity.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public TypeOfCourse Type { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public string TeachingMethod { get; set; }
        public string DescriptionForTeachingMethod { get; set; }
        public virtual List<Teacher>? Teachers { get; set; }
        public virtual List<Question>? Questions { get; set; }
    }
    public enum TypeOfCourse
    {
        Course,
        CorporateCourse
    }
}