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
    public class OtherInfoDescriptionManager : BaseManager<OtherInfoDescription>, IOtherInfoDescriptionService
    {
        readonly IOtherInfoDescriptionRepository _repository;
        public OtherInfoDescriptionManager(IOtherInfoDescriptionRepository otherInfoDescriptionRepository) : base(otherInfoDescriptionRepository)
        {
            _repository = otherInfoDescriptionRepository;
        }
    }
}