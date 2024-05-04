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
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        readonly GuysGroupAzContext _context;
        public NewsRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<List<News>> GetAllAsync()
        {
            return await _context.News.Include(b => b.NewsImages).Where(x => x.DeletedAt == null).AsNoTracking().ToListAsync();
        }

        public async Task<News> GetByIdEagerAsync(int id)
        {
            return await _context.News.Include(b => b.NewsImages).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}