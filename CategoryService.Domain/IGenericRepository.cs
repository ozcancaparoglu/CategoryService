using CategoryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CategoryService.Domain
{
    public interface IGenericRepository<T> where T : DomainBase
    {
        Task Add(T entity);
        Task BulkDelete(List<T> entities);
        Task BulkInsert(List<T> entities);
        Task BulkInsertOrUpdate(List<T> entities);
        Task BulkUpdate(List<T> entities);
        Task<int> Count();
        Task<int> CountExpression(Expression<Func<T, bool>> predicate, bool isActive = true);
        Task<ICollection<T>> Filter(Expression<Func<T, bool>> match);
        Task<T> Find(Expression<Func<T, bool>> match);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        IQueryable<T> Table();
        T Update(T entity);
    }
}
