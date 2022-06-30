using AtakDomain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtakDomain.Persistence.Configurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("Histories");
            builder.Property(x => x.TimeStamp).HasColumnType("timestamp").IsRequired();
            builder.HasOne(h => h.User).WithMany(u => u.Histories).HasForeignKey(h => h.UserId);
            builder.HasOne(h => h.Product).WithMany(p => p.Histories).HasForeignKey(h => h.ProductId);
        }
    }
}