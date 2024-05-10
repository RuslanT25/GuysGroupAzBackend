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
    public class OtherInfoRepository : GenericRepository<OtherInfo>, IOtherInfoRepository
    {
        readonly GuysGroupAzContext _context;
        public OtherInfoRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<OtherInfo>> GetAllAsync()
        {
            return await _context.OtherInfos
                .Include(b => b.OtherInfoDescriptions.Where(x => x.DeletedAt == null))
                .Where(x => x.DeletedAt == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OtherInfo> GetByIdEagerAsync(int id)
        {
            return await _context.OtherInfos
                .Include(b => b.OtherInfoDescriptions.Where(x => x.DeletedAt == null))
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}