using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProductId)
                .IsRequired();

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.Property(i => i.OriginalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(i => i.FinalValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(i => i.DiscountPercentage)
                .HasColumnType("decimal(5,2)");

            builder.Property(i => i.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(i => i.Sale)
                .WithMany(s => s.Products)
                .HasForeignKey(i => i.SaleId);
        }
    }
}
