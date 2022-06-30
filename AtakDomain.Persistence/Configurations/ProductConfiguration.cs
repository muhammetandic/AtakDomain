using AtakDomain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtakDomain.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasMany(x => x.Histories).WithOne(y => y.Product).IsRequired(true);
            builder.HasMany(x => x.OrderItems).WithOne(y => y.Product).IsRequired(true);
        }
    }
}