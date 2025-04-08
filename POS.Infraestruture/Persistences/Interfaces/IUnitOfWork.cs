using POS.Domain.Entities;
using System.Data;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaración o matrícula de nuestras interfaces a nivel de repositorio
        IGenericRepository<Category> Category {  get; }
        IGenericRepository<Provider> Provider {  get; }
        IGenericRepository<DocumentType> DocumentType {  get; }
        IUserRepository User { get; }       
        IWarehouseRepository Warehouse { get; }
        IGenericRepository<Product> Product { get; }
        IProductStockRepository ProductStock { get; }
        IGenericRepository<Purcharse> Purcharse { get; }
        IPurcharseDetailRepository PurcharseDetail { get; }
        IGenericRepository<Client> Client { get; }
        IGenericRepository<Sale> Sale { get; }
        ISaleDetailRepository SaleDetail { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        IDbTransaction BeginTransaction();
    }
}
