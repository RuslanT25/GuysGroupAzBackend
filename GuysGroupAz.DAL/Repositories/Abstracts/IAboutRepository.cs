﻿using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Abstracts
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        public Task<About> GetByIdEagerAsync(int id);
    }
}