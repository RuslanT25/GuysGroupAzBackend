using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Abstracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        List<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithDeletedAsync(int id);
        T GetById(int id);

        //Modify Commands
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Destroy(T entity);

        // Linq Commands
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(int id);
        T Find(int id);
        Task<int> CountAsync();
    }
}
