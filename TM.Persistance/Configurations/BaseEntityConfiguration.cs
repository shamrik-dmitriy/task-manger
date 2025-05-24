using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TM.Domain.Entities;

namespace TM.Persistance.Configurations;

public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {       
        builder.Property(x=>x.Id).HasColumnType("Guid").ValueGeneratedOnAdd().IsRequired();
        builder.Property(x=>x.CreatedAt).HasColumnType("DateTime").IsRequired().HasDefaultValueSql("datetime('now')");
        builder.Property(x=>x.UpdatedAt).HasColumnType("DateTime").IsRequired().HasDefaultValueSql("datetime('now')");
    }
}