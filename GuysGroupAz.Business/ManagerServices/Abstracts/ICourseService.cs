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
        public Task AddCouseWithTeachersAndQuestionsAsync(Course course, List<int> teacherIds, List<int> questionIds);
        public Task UpdateCourseWithTeachersAndQuestionsAsync(int id, Course course, List<int> teacherIds, List<int> questionIds);
        public Task<Course> GetByIdEagerAsync(int id);
    }
}