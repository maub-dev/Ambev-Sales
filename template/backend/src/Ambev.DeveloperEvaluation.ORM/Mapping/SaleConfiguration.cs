using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SaleNumber)
                .IsRequired();

            builder.Property(s => s.Date)
                .IsRequired();

            builder.Property(s => s.Customer)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.TotalValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.Branch)
                .IsRequired();

            builder.Property(s => s.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(s => s.Products)
                .WithOne(i => i.Sale)
                .HasForeignKey(i => i.SaleId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
