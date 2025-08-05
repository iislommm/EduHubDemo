using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Likes");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.LikedAt)
            .IsRequired();

        //builder.HasOne(l => l.User)
        //    .WithMany()
        //    .HasForeignKey(l => l.CreatorId)
        //    .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Video)
            .WithMany(v => v.Likes)
            .HasForeignKey(l => l.VideoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(l => new { l.UserId, l.VideoId }).IsUnique();
    }
}
