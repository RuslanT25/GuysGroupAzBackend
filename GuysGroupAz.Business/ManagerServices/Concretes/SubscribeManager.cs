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
    public class SubscribeManager : BaseManager<Subscribe>, ISubscribeService
    {
        readonly ISubscribeRepository _repository;
        public SubscribeManager(ISubscribeRepository subscribeRepository) : base(subscribeRepository)
        {
            _repository = subscribeRepository;
        }
    }
}
