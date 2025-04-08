namespace POS.Application.Dtos.Sale.Response
{
    public class SaleDetailByIdResponseDto
    {
        public int productId {  get; set; }
        public string Image { get; set; } = null!;
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
