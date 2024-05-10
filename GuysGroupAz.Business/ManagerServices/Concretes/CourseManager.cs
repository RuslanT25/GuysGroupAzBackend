using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class CourseManager : BaseManager<Course>, ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Question> _questionRepository;

        public CourseManager(ICourseRepository courseRepository, IGenericRepository<Teacher> teacherRepository, IGenericRepository<Question> questionRepository) : base(courseRepository)
        {
            _repository = courseRepository;
            _teacherRepository = teacherRepository;
            _questionRepository = questionRepository;
        }

        public async Task AddCouseWithTeachersAndQuestionsAsync(Course course, List<int> teacherIds, List<int> questionIds)
        {
            course.Teachers = await _teacherRepository
                .Where(c => teacherIds.Contains(c.Id))
                .ToListAsync();

            course.Questions = await _questionRepository
                .Where(c => questionIds.Contains(c.Id))
                .ToListAsync();

            await _repository.AddAsync(course);
        }


        public async Task<Course> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateCourseWithTeachersAndQuestionsAsync(int id, Course course, List<int> teacherIds, List<int> questionIds)
        {
            var existingCourse = await _repository.GetByIdEagerAsync(id) ?? throw new Exception("Kurs tapılmadı.");

            var existingTeachers = await _teacherRepository.Where(bi => existingCourse.Teachers.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingCourse.Teachers.RemoveAll(bi => !teacherIds.Contains(bi.Id));
            var newTeachers = await _teacherRepository.Where(bi => teacherIds.Except(existingTeachers.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();

            var existingQuestions = await _questionRepository.Where(bi => existingCourse.Questions.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingCourse.Questions.RemoveAll(bi => !questionIds.Contains(bi.Id));
            var newQuestions = await _questionRepository.Where(bi => questionIds.Except(existingQuestions.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();

            existingCourse.Teachers.AddRange(newTeachers);
            existingCourse.Questions.AddRange(newQuestions);

            existingCourse.Name = course.Name;
            existingCourse.Image = course.Image;
            existingCourse.Type = course.Type;
            existingCourse.Description = course.Description;
            existingCourse.TeachingMethod = course.TeachingMethod;
            existingCourse.DescriptionForTeachingMethod = course.DescriptionForTeachingMethod;

            _repository.Update(existingCourse);
        }
    }
}