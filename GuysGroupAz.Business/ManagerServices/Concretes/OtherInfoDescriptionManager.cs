using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.DAL.Repositories.Concretes;
using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public class OtherInfoDescriptionManager : BaseManager<OtherInfoDescription>, IOtherInfoDescriptionService
    {
        readonly IOtherInfoDescriptionRepository _repository;
        readonly IGenericRepository<OtherInfo> _otherInfoReposoitory;
        public OtherInfoDescriptionManager(IOtherInfoDescriptionRepository otherInfoDescriptionRepository, IGenericRepository<OtherInfo> courseRepository) : base(otherInfoDescriptionRepository)
        {
            _repository = otherInfoDescriptionRepository;
            _otherInfoReposoitory = courseRepository;
        }

        public async Task AddOtherInfoDescriptionWithOtherInfoAsync(OtherInfoDescription otherInfoDescription, int? otherInfoId)
        {
            if (otherInfoId.HasValue)
            {
                var otherInfo = await _otherInfoReposoitory.GetByIdAsync(otherInfoId.Value) ?? throw new Exception("OtherInfo tapılmadı.");
                otherInfoDescription.OtherInfo = otherInfo;
            }

            await _repository.AddAsync(otherInfoDescription);
        }

        public async Task<OtherInfoDescription> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateOtherInfoDescriptionWithOtherInfoAsync(int id, OtherInfoDescription otherInfoDescription, int? otherInfoId)
        {
            var existingOtherInfoDescription = await _repository.GetByIdEagerAsync(id) ?? throw new Exception("Müəllim tapılmadı.");
            existingOtherInfoDescription.OtherInfoId = otherInfoId;
            existingOtherInfoDescription.Description = otherInfoDescription.Description;

            _repository.Update(existingOtherInfoDescription);
        }
    }
}