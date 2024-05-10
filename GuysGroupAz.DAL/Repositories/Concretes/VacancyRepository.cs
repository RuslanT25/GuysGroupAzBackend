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
    public class VacancyRepository : GenericRepository<Vacancy>, IVacancyRepository
    {
        readonly GuysGroupAzContext _context;
        public VacancyRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Vacancy>> GetAllAsync()
        {
            return await _context.Vacancies
                .Include(v => v.VacancyDetails.Where(x => x.DeletedAt == null))
                .ThenInclude(vDetail => vDetail.VacancyDescriptions.Where(x => x.DeletedAt == null))
                .Where(x => x.DeletedAt == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Vacancy> GetByIdEagerAsync(int id)
        {
            return await _context.Vacancies.Include(v => v.VacancyDetails).FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}