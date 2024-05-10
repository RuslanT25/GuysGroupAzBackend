using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IVacancyService : IBaseService<Vacancy>
    {
        public Task AddVacancyWithVacancyDetailsAsync(Vacancy vacancy, List<int> vacancyDetailIds);
        public Task UpdateVacancyWithVacancyDetailsAsync(int id, Vacancy vacancy, List<int> vacancyDetailIds);
        public Task<Vacancy> GetByIdEagerAsync(int id);
    }
}