using AtakDomain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtakDomain.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
            builder.HasMany(o => o.OrderItems).WithOne(oi => oi.Order).IsRequired(true);
        }
    }
}