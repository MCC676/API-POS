namespace POS.Domain.Entities
{
    public class Warehouse : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<ProductStock> ProductsStocks { get; set; } = null!;
    }
}
