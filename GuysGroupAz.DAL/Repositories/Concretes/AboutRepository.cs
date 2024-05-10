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
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        readonly GuysGroupAzContext _context;
        public AboutRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<List<About>> GetAllAsync()
        {
            return await _context.Abouts
                .Include(b => b.AboutImages.Where(x => x.DeletedAt == null))
                .Where(x => x.DeletedAt == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<About> GetByIdEagerAsync(int id)
        {
            return await _context.Abouts.Include(b => b.AboutImages).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}