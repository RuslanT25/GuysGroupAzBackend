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
    public class VacancyManager : BaseManager<Vacancy>, IVacancyService
    {
        readonly IVacancyRepository _repository;
        public VacancyManager(IVacancyRepository vacancyRepository) : base(vacancyRepository)
        {
            _repository = vacancyRepository;
        }
    }
}