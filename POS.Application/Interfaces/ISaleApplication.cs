

using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.Product.Request;
using POS.Application.Dtos.Product.Response;
using POS.Application.Dtos.Sale.Response;

namespace POS.Application.Interfaces
{
    public interface ISaleApplication
    {
        Task<BaseResponse<IEnumerable<SaleResponseDto>>> ListSale(BaseFiltersRequest filters);
        //Task<BaseResponse<ProductByIdResponseDto>> ProductById(int productId);
        //Task<BaseResponse<bool>> RegisterProduct(ProductRequestDto requestDto);
        //Task<BaseResponse<bool>> EditProduct(int productId, ProductRequestDto requestDto);
        //Task<BaseResponse<bool>> RemoveProduct(int productId);
    }
}
