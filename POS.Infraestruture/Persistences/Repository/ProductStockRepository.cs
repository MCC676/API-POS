using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Persistences.Repository
{
    public class ProductStockRepository : IProductStockRepository
    {
        private readonly PosContext _context;

        public ProductStockRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductStock>> GetProductStockByWarehouse(int productId)
        {
            return await _context.ProductStocks
                   .AsNoTracking()
                   .Join(_context.Warehouses, ps => ps.WarehouseId, w => w.Id, (ps, w)
                   => new { ProductStock = ps, Warehouse = w })
                   .Where(x => x.ProductStock.ProductId == productId)
                   .OrderBy(x => x.Warehouse.Id)
                   .Select(x => new ProductStock
                   {
                       Warehouse = new Warehouse { Name = x.Warehouse.Name },
                       CurrentStock = x.ProductStock.CurrentStock,
                       PurchasePrice = x.ProductStock.PurchasePrice
                   })
                   .ToListAsync();
        }

        public async Task<bool> RegisterProductStock(ProductStock productStock)
        {
            await _context.AddAsync(productStock);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
