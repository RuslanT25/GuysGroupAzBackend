using GuysGroupAz.DAL.Context;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Concretes
{
    public class NewsImageRepository : GenericRepository<NewsImage>,INewsImageRepository
    {
        readonly GuysGroupAzContext _context;

        public NewsImageRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }
    }
}