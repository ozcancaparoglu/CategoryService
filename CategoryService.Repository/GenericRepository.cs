using CategoryService.Domain;
using CategoryService.Domain.Common;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CategoryService.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : DomainBase
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> Table()
        {
            return context.Set<T>().AsQueryable();
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await context.Set<T>().SingleOrDefaultAsync(match);
        }

        public virtual async Task<ICollection<T>> Filter(Expression<Func<T, bool>> match)
        {
            return await context.Set<T>().Where(match).ToListAsync();
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public T Update(T entity)
        {
            var entityEntry = context.Set<T>().Update(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<int> Count()
        {
            return await context.Set<T>().CountAsync();
        }

        public async Task<int> CountExpression(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await context.Set<T>().Where(predicate).CountAsync();
        }

        public virtual async Task BulkUpdate(List<T> entities)
        {
            await context.BulkUpdateAsync(entities);
        }

        public virtual async Task BulkInsertOrUpdate(List<T> entities)
        {
            await context.BulkInsertOrUpdateAsync(entities);
        }

        public virtual async Task BulkInsert(List<T> entities)
        {
            await context.BulkInsertAsync(entities);
        }

        public virtual async Task BulkDelete(List<T> entities)
        {
            await context.BulkDeleteAsync(entities);
        }
    }
}
