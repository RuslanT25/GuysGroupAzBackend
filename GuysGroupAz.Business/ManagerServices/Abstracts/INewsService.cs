using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface INewsService : IBaseService<News>
    {
        public Task AddNewsWithImagesAsync(News news, List<int> newsImageIds);
        public Task UpdateNewsWithImagesAsync(int id, News news, List<int> newsImageIds);
        public Task<News> GetByIdEagerAsync(int id);
    }
}