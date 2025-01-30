using BooksMine.DataAccess.Repository.interfaces;
using BooksMineWeb.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksMine.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            dbSet.Add(entity);
            await SaveAsync();
        }

       
        public async Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includeProperties =null
            )
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }


        public async Task<T> GetAsync(
            Expression<Func<T, bool>> filter = null, 
            bool tracked = true,
            Expression<Func<T, object>>[]? includeProperties = null

            )
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            await SaveAsync();
        }

       
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        
    }
}
