using GuysGroupAz.DAL.Context;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.DTOs.BlogImage;
using GuysGroupAz.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Concretes
{
    public class BlogImageRepository : GenericRepository<BlogImage>, IBlogImageRepository
    {
        readonly GuysGroupAzContext _context;

        public BlogImageRepository(GuysGroupAzContext context) : base(context)
        {
            _context = context;
        }
    }
}