using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class VacancyManager : BaseManager<Vacancy>, IVacancyService
    {
        readonly IVacancyRepository _repository;
        readonly IGenericRepository<VacancyDetail> _vacancyDetailRepository;
        public VacancyManager(IVacancyRepository vacancyRepository, IGenericRepository<VacancyDetail> vacancyDetailRepository) : base(vacancyRepository)
        {
            _repository = vacancyRepository;
            _vacancyDetailRepository = vacancyDetailRepository;
        }

        public async Task AddVacancyWithVacancyDetailsAsync(Vacancy vacancy, List<int> vacancyDetailIds)
        {
            vacancy.VacancyDetails = await _vacancyDetailRepository.Where(bi => vacancyDetailIds.Contains(bi.Id)).ToListAsync();
            await _repository.AddAsync(vacancy);
        }

        public async Task<Vacancy> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateVacancyWithVacancyDetailsAsync(int id, Vacancy vacancy, List<int> vacancyDetailIds)
        {
            var existingVacancy = await _repository.GetByIdEagerAsync(id);
            if (existingVacancy == null)
            {
                throw new Exception("Vakansiya tapılmadı.");
            }

            var existingVacancyDetails = await _vacancyDetailRepository.Where(bi => existingVacancy.VacancyDetails.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingVacancy.VacancyDetails.RemoveAll(bi => !vacancyDetailIds.Contains(bi.Id));
            var newVacancyDetails = await _vacancyDetailRepository.Where(bi => vacancyDetailIds.Except(existingVacancyDetails.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingVacancy.VacancyDetails.AddRange(newVacancyDetails);

            existingVacancy.Title = vacancy.Title;
            existingVacancy.Email = vacancy.Email;
            existingVacancy.PublishDate = vacancy.PublishDate;

            _repository.Update(existingVacancy);
        }
    }
}