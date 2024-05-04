using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class NewsImageManager : BaseManager<NewsImage> ,INewsImageService
    {
        readonly INewsImageRepository _repository;
        public NewsImageManager(INewsImageRepository newsImage) : base(newsImage)
        {
            _repository = newsImage;
        }
    }
}