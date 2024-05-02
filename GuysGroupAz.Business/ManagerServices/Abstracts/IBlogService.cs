using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IBlogService : IBaseService<Blog>
    {
        public Task AddBlogWithImagesAsync(Blog blog, List<int> blogImageIds);
        public Task UpdateBlogWithImagesAsync(int id, Blog blog, List<int> blogImageIds);
        public Task<Blog> GetByIdEagerAsync(int id);
    }
}