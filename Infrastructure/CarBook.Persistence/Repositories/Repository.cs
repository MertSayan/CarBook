using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly CarBookContext _context;

        public Repository(CarBookContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            //return await _context.Set<T>().ToListAsync();
            return await _context.Set<T>()
                             .Where(e => e.DeletedDate == null)
                             .ToListAsync();
        }

		public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
		{
			return await _context.Set<T>().SingleOrDefaultAsync(filter);
		}

		public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity!=null && entity.DeletedDate == null)
            {
                return entity;
            }
            return null;
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity is Car /*|| entity is Blog*/)
            {
                _context.Set<T>().Remove(entity);
            }
            else
            {
                entity.DeletedDate = DateTime.Now;
            }
            //_context.Set<T>().Remove(entity);

            ////entity.DeletedDate = DateTime.Now;
            

            //_context.Set<T>().Remove(entity);
               
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
