using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Ordering;
using POS.Application.Dtos.Purcharse.Response;
using POS.Application.Dtos.Sale.Request;
using POS.Application.Dtos.Sale.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Utilities.Static;
using WatchDog;

namespace POS.Application.Services
{
    public class SaleApplication : ISaleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;
        private readonly IFileStorageLocalApplication _fileStorage;

        public SaleApplication(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery, IFileStorageLocalApplication fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;
            _fileStorage = fileStorage;
        }
        public async Task<BaseResponse<IEnumerable<SaleResponseDto>>> ListSale(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<SaleResponseDto>>();

            try
            {
                var sales = _unitOfWork.Sale.GetAllQuerable()
                                .AsNoTracking()
                                .Include(x => x.VoucherDocumentType)
                                .Include(x => x.Client)
                                .Include(x => x.Warehouse)
                                .AsQueryable();

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            sales = sales.Where(x => x.VoucherNumber!.Contains(filters.TextFilter));
                            break;
                    }
                }

                if (filters.StateFilter is not null)
                {
                    sales = sales.Where(x => x.State.Equals(filters.StateFilter));
                }

                if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
                {
                    sales = sales.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate)
                        && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate)
                        .AddDays(1));
                }
                filters.Sort ??= "Id";

                var items = await _orderingQuery.Ordering(filters, sales, (bool)filters.Download!).ToListAsync();

                response.IsSuccess = true;
                response.TotalRecords = await sales.CountAsync();
                response.Data = _mapper.Map<IEnumerable<SaleResponseDto>>(items);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<SaleByIdResponseDto>> SaleById(int saleId)
        {
            var response = new BaseResponse<SaleByIdResponseDto>();

            try
            {
                var sales = await _unitOfWork.Sale.GetByIdAsync(saleId);

                if (sales is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                var saleDetail = await _unitOfWork.SaleDetail.GetSaleDetailBySaleId(sales.Id);
                sales.SaleDetails = saleDetail.ToList();

                response.IsSuccess = true;
                response.Data = _mapper.Map<SaleByIdResponseDto>(sales);
                response.Message = ReplyMessage.MESSAGE_QUERY;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterSale(SaleRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var sale = _mapper.Map<Sale>(requestDto);
                sale.State = (int)StateTypes.Active;
                await _unitOfWork.Sale.RegisterAsync(sale);

                foreach (var item in sale.SaleDetails)
                {
                    var productStock = await _unitOfWork.ProductStock
                        .GetProductStockByProductId(item.ProductId, requestDto.WarehouseId);
                    productStock.CurrentStock -= item.Quantity;
                    await _unitOfWork.ProductStock.UpdateCurrentByProducts(productStock);
                }

                transaction.Commit();
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<bool>> CancelSale(int saleId)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var sale = await SaleById(saleId);
                response.Data = await _unitOfWork.Sale.RemoveAsync(saleId);

                foreach (var item in sale.Data!.saleDetails)
                {
                    var productStock = await _unitOfWork.ProductStock
                        .GetProductStockByProductId(item.productId, sale.Data.WarehouseId);
                    productStock.CurrentStock += item.Quantity;
                    await _unitOfWork.ProductStock.UpdateCurrentByProducts(productStock);
                }

                transaction.Commit();
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_CANCEL;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<ProductStockByWarehouseIdResponseDto>>> GetProductStockByWarehouseId(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<ProductStockByWarehouseIdResponseDto>>();

            try
            {
                var products = _unitOfWork.SaleDetail.GetProductStockByWarehouseId(filters.Id);

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            products = products.Where(x => x.Code!.Contains(filters.TextFilter));
                            break;
                        case 2:
                            products = products.Where(x => x.Name!.Contains(filters.TextFilter));
                            break;  
                    }
                }

                filters.Sort ??= "Id";
                var items = await _orderingQuery.Ordering(filters, products, !(bool)filters.Download!).ToListAsync();

                response.IsSuccess = true;
                response.TotalRecords = await products.CountAsync();
                response.Data = _mapper.Map<IEnumerable<ProductStockByWarehouseIdResponseDto>>(items);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }
            return response;
        }
    }
}
