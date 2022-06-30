using AtakDomain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtakDomain.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasMany(x => x.Histories).WithOne(x => x.User).IsRequired(true);
            builder.HasMany(x => x.Orders).WithOne(x => x.User).IsRequired(true);
        }
    }
}