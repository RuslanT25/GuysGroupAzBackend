using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IOtherInfoDescriptionService : IBaseService<OtherInfoDescription>
    {
        public Task AddOtherInfoDescriptionWithOtherInfoAsync(OtherInfoDescription otherInfoDescription, int? otherInfoId);
        public Task UpdateOtherInfoDescriptionWithOtherInfoAsync(int id, OtherInfoDescription otherInfoDescription, int? otherInfoId);
        public Task<OtherInfoDescription> GetByIdEagerAsync(int id);
    }
}