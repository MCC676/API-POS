using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<bool> RegisterAsync(T Entity);
        Task<bool> EditAsync(T Entity);
        Task<bool> RemoveAsync(int Id);
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
    }
}
