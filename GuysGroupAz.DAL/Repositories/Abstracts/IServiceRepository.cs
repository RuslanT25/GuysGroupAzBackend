﻿using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Abstracts
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        public Task<Service> GetByIdEagerAsync(int id);
    }
}