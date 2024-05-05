using GuysGroupAz.DAL.Context;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Concretes
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        readonly GuysGroupAzContext _context;
        public CourseRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(b => b.Teachers).Where(x => x.DeletedAt == null).AsNoTracking().ToListAsync();
        }

        public async Task<Course> GetByIdEagerAsync(int id)
        {
            return await _context.Courses.Include(b => b.Teachers).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}