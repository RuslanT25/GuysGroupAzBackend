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
    public class VacancyDetailsManager : BaseManager<VacancyDetail>, IVacancyDetailsService
    {
        readonly IVacancyDetailsRepository _repository;
        private readonly IGenericRepository<VacancyDescription> _vacancyDescriptionRepository;
        public VacancyDetailsManager(IVacancyDetailsRepository vacancyDetailsRepository, IGenericRepository<VacancyDescription> vacancyDescriptionRepository) : base(vacancyDetailsRepository)
        {
            _repository = vacancyDetailsRepository;
            _vacancyDescriptionRepository = vacancyDescriptionRepository;
        }

        public async Task AddVacancyDetailWithVacancyDescriptionsAsync(VacancyDetail vacancyDetail, List<int> vacancyDescriptionIds)
        {
            vacancyDetail.VacancyDescriptions = await _vacancyDescriptionRepository.Where(bi => vacancyDescriptionIds.Contains(bi.Id) && bi.DeletedAt == null).ToListAsync();
            await _repository.AddAsync(vacancyDetail);
        }

        public async Task<VacancyDetail> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateVacancyDetailWithVacancyDescriptionsAsync(int id, VacancyDetail vacancyDetail, List<int> vacancyDescriptionIds)
        {
            var existingVacancyDetail = await _repository.GetByIdEagerAsync(id) ?? throw new Exception("Vakansiya detalı tapılmadı.");
            var existingVacancyDescription = await _vacancyDescriptionRepository.Where(bi => existingVacancyDetail.VacancyDescriptions.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingVacancyDetail.VacancyDescriptions.RemoveAll(bi => !vacancyDescriptionIds.Contains(bi.Id));
            var newBlogImages = await _vacancyDescriptionRepository.Where(bi => vacancyDescriptionIds.Except(existingVacancyDescription.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingVacancyDetail.VacancyDescriptions.AddRange(newBlogImages);

            existingVacancyDetail.Title = vacancyDetail.Title;

            _repository.Update(existingVacancyDetail);
        }
    }
}