using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface ITeacherService : IBaseService<Teacher>
    {
        public Task AddTeacherWithCourseAsync(Teacher teacher, int? courseId);
        public Task UpdateTeacherWithCourseAsync(int id, Teacher teacher, int? courseId);
        public Task<Teacher> GetByIdEagerAsync(int id);
    }
}