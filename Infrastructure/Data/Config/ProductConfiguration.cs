using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Uom).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.HNAPPN).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PictureURL).IsRequired();
        builder.Property(p => p.isEnabled).IsRequired();
        builder.HasOne(p => p.ProductFactory).WithMany()
            .HasForeignKey(p => p.ProductFactoryId);
        builder.HasOne(p => p.ProductCategory).WithMany()
            .HasForeignKey(p => p.ProductCategoryId);
        
    }
}
