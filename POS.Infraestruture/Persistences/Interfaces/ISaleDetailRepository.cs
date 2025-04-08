using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface ISaleDetailRepository
    {
        Task<IEnumerable<SaleDetail>> GetSaleDetailBySaleId(int saleId);
    }
}
