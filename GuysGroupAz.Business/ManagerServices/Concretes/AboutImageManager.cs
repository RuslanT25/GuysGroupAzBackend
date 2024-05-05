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
    public class AboutImageManager : BaseManager<AboutImage>,IAboutImageService
    {
        readonly IAboutImageRepository _repository;
        public AboutImageManager(IAboutImageRepository aboutImageRepository) : base(aboutImageRepository)
        {
            _repository = aboutImageRepository;
        }
    }
}