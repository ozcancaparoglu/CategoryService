using CategoryService.Domain.Common;
using System.Threading.Tasks;

namespace CategoryService.Domain
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : DomainBase;
        Task<int> CommitAsync();
        void Rollback();
    }
}
