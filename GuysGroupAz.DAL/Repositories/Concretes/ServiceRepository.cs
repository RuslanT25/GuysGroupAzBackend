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
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        readonly GuysGroupAzContext _context;
        public ServiceRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services
                .Include(b => b.Questions.Where(x => x.DeletedAt == null))
                .Where(x => x.DeletedAt == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Service> GetByIdEagerAsync(int id)
        {
            return await _context.Services
                .Include(b => b.Questions.Where(x => x.DeletedAt == null))
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}