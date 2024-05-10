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
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        readonly GuysGroupAzContext _context;
        public BlogRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs
                .Include(b => b.BlogImages.Where(x => x.DeletedAt == null))
                .Where(x => x.DeletedAt == null)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Blog> GetByIdEagerAsync(int id)
        {
            return await _context.Blogs.Include(b => b.BlogImages).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}