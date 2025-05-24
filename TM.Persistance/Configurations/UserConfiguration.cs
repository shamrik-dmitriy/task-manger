using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TM.Domain.Entities.User;
using Task = TM.Domain.Entities.Task.Task;

namespace TM.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.Property(x=>x.Name).HasMaxLength(20).IsRequired();
        
        builder.Property(x=>x.Email).HasMaxLength(100).IsRequired();
        builder.HasIndex(x=>x.Email).IsUnique();
        builder.HasAlternateKey(x=>x.Email);
        
        builder.Property(x=>x.Password).HasColumnType("BLOB").IsRequired();
        builder.Property(x=>x.Salt).HasColumnType("BLOB").IsRequired();
        
        builder.HasMany(x=>x.Tasks).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);
    }
}