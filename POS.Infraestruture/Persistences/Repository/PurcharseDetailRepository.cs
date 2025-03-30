using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repository
{
    public class PurcharseDetailRepository : IPurcharseDetailRepository
    {
        private readonly PosContext _context;

        public PurcharseDetailRepository(PosContext posContext)
        {
            _context = posContext;
        }
        public async Task<IEnumerable<PurcharseDetail>> GetPurcharseDetailByPurcharseId(int purcharseId)
        {
            var response = await _context.Products
                .AsNoTracking()
                .Join(_context.PurcharseDetails, p => p.Id, pd => pd.ProductId, (p, pd)
                    => new { Product = p, PurcharseDetail = pd })
                .Where(x => x.PurcharseDetail.PurcharseId == purcharseId)
                .Select(x => new PurcharseDetail
                {
                    ProductId = x.Product.Id,
                    Product = new Product
                    {
                        Image = x.Product.Image,
                        Code = x.Product.Code,
                        Name = x.Product.Name,
                    },
                    Quantity = x.PurcharseDetail.Quantity,
                    UnitPurchasePrice = x.PurcharseDetail.UnitPurchasePrice,
                    Total = x.PurcharseDetail.Total
                })
                .ToListAsync();

            return response;
        }
    }
}
