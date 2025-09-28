using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Date).IsRequired();
            builder.Property(u => u.UserId).HasColumnType("uuid").IsRequired();
            builder.HasOne(c => c.User)
               .WithMany()
               .HasForeignKey(c => c.UserId)
               .IsRequired();

            builder.OwnsMany(p => p.Products, a =>
            {
                a.ToTable("CartItems");

                a.HasKey("CartId", "ProductId");
                a.WithOwner().HasForeignKey("CartId");
                a.Property(i => i.Quantity).IsRequired();
                a.Property(i => i.ProductId).IsRequired();
                a.HasOne(ci => ci.Product)
                    .WithMany()
                    .HasForeignKey(ci => ci.ProductId)
                    .IsRequired();
            });

            builder.Navigation(c => c.Products)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
