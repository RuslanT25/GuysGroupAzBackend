using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class OtherInfoManager : BaseManager<OtherInfo>, IOtherInfoService
    {
        readonly IOtherInfoRepository _repository;
        private readonly IGenericRepository<OtherInfoDescription> _otherInfoDescriptionRepository;
        public OtherInfoManager(IOtherInfoRepository otherInfoRepository, IGenericRepository<OtherInfoDescription> otherInfoDescriptionRepository) : base(otherInfoRepository)
        {
            _repository = otherInfoRepository;
            _otherInfoDescriptionRepository = otherInfoDescriptionRepository;

        }

        public async Task AddOtherInfoWithOtherInfoDescriptionsAsync(OtherInfo otherInfo, List<int> otherInfoDescriptionIds)
        {
            otherInfo.OtherInfoDescriptions = await _otherInfoDescriptionRepository.Where(bi => otherInfoDescriptionIds.Contains(bi.Id)).ToListAsync();
            await _repository.AddAsync(otherInfo);
        }

        public async Task<OtherInfo> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateOtherInfoWithOtherInfoDescriptionsAsync(int id, OtherInfo otherInfo, List<int> otherInfoDescriptionIds)
        {
            var existingOtherInfo = await _repository.GetByIdEagerAsync(id) ?? throw new Exception("Kurs tapılmadı.");
            var existingOtherInfoDescriptions = await _otherInfoDescriptionRepository.Where(bi => existingOtherInfo.OtherInfoDescriptions.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingOtherInfo.OtherInfoDescriptions.RemoveAll(bi => !otherInfoDescriptionIds.Contains(bi.Id));
            var newTeachers = await _otherInfoDescriptionRepository.Where(bi => otherInfoDescriptionIds.Except(existingOtherInfoDescriptions.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingOtherInfo.OtherInfoDescriptions.AddRange(newTeachers);

            existingOtherInfo.Title = otherInfo.Title;
            _repository.Update(existingOtherInfo);
        }
    }
}