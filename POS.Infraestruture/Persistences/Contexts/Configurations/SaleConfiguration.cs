using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
           // builder.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C3FFDB03EA4D");
           builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("saleId");

            builder.Property(e => e.VoucherNumber)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.SubTotal).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Igv).HasColumnType("decimal(10,2)");
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)");


            //builder.HasOne(d => d.Client).WithMany(p => p.Sales)
            //    .HasForeignKey(d => d.ClientId)
            //    .HasConstraintName("FK__Sales__ClientId__6C190EBB");
        }
    }
}
