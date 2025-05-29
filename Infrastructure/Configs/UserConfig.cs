using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraStructure.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasCharSet("utf8mb4");

        builder.Property(u => u.Id)
            .HasColumnType("varchar(36)")
            .IsRequired();
    }
}
