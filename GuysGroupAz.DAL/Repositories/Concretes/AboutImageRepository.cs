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
    public class AboutImageRepository : GenericRepository<AboutImage>,IAboutImageRepository
    {
        public AboutImageRepository(GuysGroupAzContext context) : base(context)
        {
        }
    }
}