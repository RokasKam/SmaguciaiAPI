using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Product)
            .HasForeignKey(p => p.CategoryId);
        builder
            .HasOne(p => p.Manufacturer)
            .WithMany(m => m.Product)
            .HasForeignKey(p => p.ManufacturerId);
    }
}
