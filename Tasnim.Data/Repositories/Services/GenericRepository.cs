using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;

namespace Tasnim.Data.Repositories.Services
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly TasnimDbContext dbContext;

        internal DbSet<T> dbSet;

        public GenericRepository(TasnimDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<T> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entry = await dbSet.FirstOrDefaultAsync(expression);

            dbSet.Remove(entry);

            await dbContext.SaveChangesAsync();

            return entry;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? dbSet : dbSet.Where(expression);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = dbSet.Update(entity);

            await dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
