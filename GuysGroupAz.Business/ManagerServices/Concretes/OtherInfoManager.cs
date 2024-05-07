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
    public class OtherInfoManager : BaseManager<OtherInfo>,IOtherInfoService
    {
        readonly IOtherInfoRepository _repository;
        public OtherInfoManager(IOtherInfoRepository otherInfoRepository) :base(otherInfoRepository)
        {
            _repository = otherInfoRepository;
        }
    }
}