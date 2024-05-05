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
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        readonly GuysGroupAzContext _context;
        public TeacherRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.Include(b => b.Course).Where(x => x.DeletedAt == null).AsNoTracking().ToListAsync();
        }

        public async Task<Teacher> GetByIdEagerAsync(int id)
        {
            return await _context.Teachers.Include(b => b.Course).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}