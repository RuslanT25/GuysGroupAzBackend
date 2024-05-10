using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IVacancyDetailsService : IBaseService<VacancyDetail>
    {
        public Task AddVacancyDetailWithVacancyDescriptionsAsync(VacancyDetail vacancyDetail, List<int> vacancyDescriptionIds);
        public Task UpdateVacancyDetailWithVacancyDescriptionsAsync(int id, VacancyDetail vacancyDetail, List<int> vacancyDescriptionIds);
        public Task<VacancyDetail> GetByIdEagerAsync(int id);
    }
}