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
    public class AboutManager : BaseManager<About>, IAboutService
    {
        readonly IAboutRepository _repository;
        public AboutManager(IAboutRepository aboutRepository) : base(aboutRepository)
        {
            _repository = aboutRepository;
        }
    }
}
