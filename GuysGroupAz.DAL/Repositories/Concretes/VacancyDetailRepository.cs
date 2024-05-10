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
    public class VacancyDetailRepository : GenericRepository<VacancyDetail>, IVacancyDetailsRepository
    {
        readonly GuysGroupAzContext _context;
        public VacancyDetailRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<VacancyDetail>> GetAllAsync()
        {
            return await _context.VacancyDetails
                .Include(b => b.VacancyDescriptions.Where(x => x.DeletedAt == null))
                .Where(x => x.DeletedAt == null)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<VacancyDetail> GetByIdEagerAsync(int id)
        {
            return await _context.VacancyDetails
                .Include(b => b.VacancyDescriptions.Where(x => x.DeletedAt == null))
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}