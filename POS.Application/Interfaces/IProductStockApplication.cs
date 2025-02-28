using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.ProductStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces
{
    public interface IProductStockApplication
    {
        Task<BaseResponse<IEnumerable<ProductStockByWarehouseResponseDto>>>
            GetProductStockByWarehouseAsync(int productId);
    }
}
