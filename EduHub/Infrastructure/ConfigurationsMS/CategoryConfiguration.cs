using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfigurationsMS;

public class CategoryConfiguration
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);


        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.HasMany(c => c.Videos)
            .WithOne(v => v.Category)
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.ToTable("Categories");
    }
}

