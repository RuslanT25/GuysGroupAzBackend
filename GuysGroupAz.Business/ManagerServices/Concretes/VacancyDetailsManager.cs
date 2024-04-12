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
    public class VacancyDetailsManager : BaseManager<VacancyDetail>, IVacancyDetailsService
    {
        readonly IVacancyDetailsRepository _repository;
        public VacancyDetailsManager(IVacancyDetailsRepository vacancyDetailsRepository) : base(vacancyDetailsRepository)
        {
            _repository = vacancyDetailsRepository;
        }
    }
}