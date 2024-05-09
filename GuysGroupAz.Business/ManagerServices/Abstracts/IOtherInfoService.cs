using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IOtherInfoService : IBaseService<OtherInfo>
    {
        public Task AddOtherInfoWithOtherInfoDescriptionsAsync(OtherInfo otherInfo, List<int> otherInfoDescriptionIds);
        public Task UpdateOtherInfoWithOtherInfoDescriptionsAsync(int id, OtherInfo otherInfo, List<int> otherInfoDescriptionIds);
        public Task<OtherInfo> GetByIdEagerAsync(int id);
    }
}