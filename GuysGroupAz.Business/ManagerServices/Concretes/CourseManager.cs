using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class CourseManager : BaseManager<Course>, ICourseService
    {
        readonly ICourseRepository _repository;
        public CourseManager(ICourseRepository courseRepository) : base(courseRepository)
        {
            _repository = courseRepository;
        }
    }
}