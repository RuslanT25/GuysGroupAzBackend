using GuysGroupAz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Abstracts
{
    public interface IServiceService : IBaseService<Service>
    {
        public Task AddServiceWithQuestionsAsync(Service service, List<int> questionIds);
        public Task UpdateServiceWithQuestionsAsync(int id, Service service, List<int> questionIds);
        public Task<Service> GetByIdEagerAsync(int id);
    }
}