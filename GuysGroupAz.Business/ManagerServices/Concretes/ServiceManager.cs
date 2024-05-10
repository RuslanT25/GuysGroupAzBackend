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
    public class ServiceManager : BaseManager<Service>, IServiceService
    {
        readonly IServiceRepository _repository;
        private readonly IGenericRepository<Question> _questionRepository;
        public ServiceManager(IServiceRepository serviceRepository, IGenericRepository<Question> questionRepository) : base(serviceRepository)
        {
            _repository = serviceRepository;
            _questionRepository = questionRepository;
        }

        public async Task AddServiceWithQuestionsAsync(Service service, List<int> questionIds)
        {
            service.Questions = await _questionRepository.Where(bi => questionIds.Contains(bi.Id)).ToListAsync();
            await _repository.AddAsync(service);
        }

        public async Task<Service> GetByIdEagerAsync(int id)
        {
            return await _repository.GetByIdEagerAsync(id);
        }

        public async Task UpdateServiceWithQuestionsAsync(int id, Service service, List<int> questionIds)
        {
            var existingService = await _repository.GetByIdEagerAsync(id);
            if (existingService == null)
            {
                throw new Exception("Servis tapılmadı.");
            }

            var existingQuestions = await _questionRepository.Where(bi => existingService.Questions.Select(b => b.Id).Contains(bi.Id)).ToListAsync();
            existingService.Questions.RemoveAll(bi => !questionIds.Contains(bi.Id));
            var newQuestions = await _questionRepository.Where(bi => questionIds.Except(existingQuestions.Select(bi => bi.Id)).Contains(bi.Id)).ToListAsync();
            existingService.Questions.AddRange(newQuestions);

            existingService.Name = service.Name;
            existingService.Description = service.Description;

            _repository.Update(existingService);
        }
    }
}