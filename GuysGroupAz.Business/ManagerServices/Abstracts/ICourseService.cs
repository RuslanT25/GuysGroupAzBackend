using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface ICourseService : IBaseService<Course>
    {
        public Task AddCouseWithTeachersAsync(Course course, List<int> teacherIds);
        public Task UpdateCourseWithTeachersAsync(int id, Course course, List<int> teacherIds);
        public Task<Course> GetByIdEagerAsync(int id);
    }
}