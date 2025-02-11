using POS.Domain.Entities;
using System.Linq.Expressions;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllQuerable();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetSelectAsync();
        Task<T> GetByIdAsync(int Id);
        Task<bool> RegisterAsync(T Entity);
        Task<bool> EditAsync(T Entity);
        Task<bool> RemoveAsync(int Id);
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
    }
}
