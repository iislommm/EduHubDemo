using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfigurationsPS;

public class RoleConfiguration
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(ur => ur.RoleId);

        builder.Property(ur => ur.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ur => ur.Description)
            .HasMaxLength(200);
    }
}
