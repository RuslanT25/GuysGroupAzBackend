using GuysGroupAz.Business.ManagerServices.Abstracts;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.Business.ManagerServices.Concretes
{
    public abstract class BaseManager<T> : IBaseService<T> where T : BaseEntity
    {
        readonly IGenericRepository<T> _repository;
        protected BaseManager(IGenericRepository<T> genericRepository)
        {
            _repository = genericRepository;
        }
        public void Add(T entity)
        {
            var result = _repository.Any(x => x.Id == entity.Id);
            if (!result)
            {
                _repository.Add(entity);
            }
        }

        public  async Task AddAsync(T entity)
        {
            var result = await _repository.AnyAsync(x => x.Id == entity.Id);
            if (!result)
            {
                _repository.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            var result = _repository.GetByIdAsync(entity.Id);
            if (result != null)
            {
                _repository.Delete(entity);
            }
        }

        public void Destroy(T entity)
        {
            var result = _repository.GetByIdAsync(entity.Id);
            if (result != null)
            {
                _repository.Destroy(entity);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            var count = await _repository.CountAsync();
            if (count != 0)
            {
                return await _repository.GetAllAsync();
            }

            return null;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<T> GetByIdWithDeletedAsync(int id)
        {
            return await _repository.GetByIdWithDeletedAsync(id);
        }

        public void Update(T entity)
        {
            var result = _repository.GetById(entity.Id);
            if (result != null)
            {
                _repository.Update(entity);
            }
        }
    }
}
