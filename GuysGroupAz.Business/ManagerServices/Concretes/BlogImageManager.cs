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
    public class BlogImageManager : BaseManager<BlogImage>, IBlogImageService
    {
        readonly IBlogImageRepository _repository;
        public BlogImageManager(IBlogImageRepository blogImageRepository) : base(blogImageRepository)
        {
            _repository = blogImageRepository;
        }
    }
}
