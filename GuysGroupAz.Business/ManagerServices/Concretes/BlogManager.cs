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
    public class BlogManager : BaseManager<Blog>, IBlogImageService
    {
        readonly IBlogRepository _repository;
        public BlogManager(IBlogRepository blogRepository) : base(blogRepository)
        {
            _repository = blogRepository;
        }
    }
}