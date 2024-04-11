using GuysGroupAz.DAL.Context;
using GuysGroupAz.DAL.Repositories.Abstracts;
using GuysGroupAz.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuysGroupAz.DAL.Repositories.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly GuysGroupAzContext _context;
        public GenericRepository(GuysGroupAzContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }

        public void Destroy(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => x.DeletedAt == null).AsNoTracking().ToListAsync();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().Where(x => x.DeletedAt == null).AsNoTracking().ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().Where(x => x.DeletedAt == null).FirstOrDefaultAsync(x => x.Id == id);
        }
            
        public T GetById(int id)
        {
            return _context.Set<T>().Where(x => x.DeletedAt == null).FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            var model = _context.Set<T>().Find(entity.Id);
            if (model != null)
            {
                _context.Entry(model).State = EntityState.Detached;
                _context.Entry(entity).State = EntityState.Modified;
                entity.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}