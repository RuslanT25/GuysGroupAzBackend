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
    public class OtherInfoDescriptionRepository : GenericRepository<OtherInfoDescription>, IOtherInfoDescriptionRepository
    {
        readonly GuysGroupAzContext _context;
        public OtherInfoDescriptionRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<OtherInfoDescription>> GetAllAsync()
        {
            return await _context.OtherInfoDescriptions.Include(b => b.OtherInfo).Where(x => x.DeletedAt == null).AsNoTracking().ToListAsync();
        }

        public async Task<OtherInfoDescription> GetByIdEagerAsync(int id)
        {
            return await _context.OtherInfoDescriptions.Include(b => b.OtherInfo).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}