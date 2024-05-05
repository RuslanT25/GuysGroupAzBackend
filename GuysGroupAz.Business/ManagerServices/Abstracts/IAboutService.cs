using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IAboutService : IBaseService<About>
    {
        public Task AddAboutWithAboutImagesAsync(About about, List<int> aboutImageIds);
        public Task UpdateAboutWithAboutImagesAsync(int id, About about, List<int> aboutImageIds);
        public Task<About> GetByIdEagerAsync(int id);
    }
}