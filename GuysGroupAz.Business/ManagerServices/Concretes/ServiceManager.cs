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
    public class ServiceManager : BaseManager<Service>,IServiceService
    {
        readonly IServiceRepository _repository;
        public ServiceManager(IServiceRepository serviceRepository) : base(serviceRepository)
        {
            _repository = serviceRepository;
        }
    }
}
