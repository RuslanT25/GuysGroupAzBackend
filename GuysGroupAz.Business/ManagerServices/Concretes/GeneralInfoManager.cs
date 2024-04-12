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
    public class GeneralInfoManager : BaseManager<GeneralInfo>, IGeneralInfoService
    {
        readonly IGeneralInfoRepository _repository;
        public GeneralInfoManager(IGeneralInfoRepository generalInfoRepository) : base(generalInfoRepository)
        {
            _repository = generalInfoRepository;
        }
    }
}