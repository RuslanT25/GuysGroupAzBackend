﻿using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Abstracts
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        public Task<Blog> GetByIdEagerAsync(int id);
    }
}