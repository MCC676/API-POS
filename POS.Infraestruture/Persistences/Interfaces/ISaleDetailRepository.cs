using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface ISaleDetailRepository
    {
        Task<IEnumerable<SaleDetail>> GetSaleDetailBySaleId(int saleId);
        IQueryable<Product> GetProductStockByWarehouseId(int warehouseId);
    }
}
