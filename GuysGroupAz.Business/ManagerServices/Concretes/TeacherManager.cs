using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class TeacherManager : BaseManager<Teacher>, ITeacherService
    {
        private readonly ITeacherRepository _repository;
        private readonly IGenericRepository<Course> _courseRepository;

        public TeacherManager(ITeacherRepository teacherRepository, IGenericRepository<Course> courseRepository) : base(teacherRepository)
        {
            _repository = teacherRepository;
            _courseRepository = courseRepository;
        }

        public async Task AddTeacherWithCourseAsync(Teacher teacher, int? courseId)
        {
            if (courseId.HasValue)
            {
                var course = await _courseRepository.GetByIdAsync(courseId.Value) ?? throw new Exception("Course not found");
                teacher.Course = course;
            }

            await _repository.AddAsync(teacher);
        }

        public async Task UpdateTeacherWithCourseAsync(int id, Teacher teacher, int? courseId)
        {
            var existingTeacher = await _repository.GetByIdEagerAsync(id) ?? throw new Exception("Müəllim tapılmadı.");
            existingTeacher.CourseId = courseId;
            existingTeacher.Profession = teacher.Profession;
            existingTeacher.Name = teacher.Name;
            existingTeacher.SurName = teacher.SurName;
            existingTeacher.Image = teacher.Image;

            _repository.Update(existingTeacher);
        }
        public async Task<Teacher> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }
    }
}