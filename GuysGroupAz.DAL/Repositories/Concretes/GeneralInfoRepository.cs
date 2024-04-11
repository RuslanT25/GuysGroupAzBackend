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
    public class GeneralInfoRepository : GenericRepository<GeneralInfo>, IGeneralInfoRepository
    {
        public GeneralInfoRepository(GuysGroupAzContext context) : base(context)
        {
        }
    }
}
