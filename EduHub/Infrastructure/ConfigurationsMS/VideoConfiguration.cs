using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(v => v.VideoId);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(v => v.Description)
            .HasMaxLength(1000);

        builder.Property(v => v.MB)
            .IsRequired();

        builder.Property(v => v.Views)
            .IsRequired();

        builder.Property(v => v.Duration)
            .IsRequired();

        builder.Property(v => v.VideoUrl)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(v => v.Price)
            .IsRequired();

        builder.HasOne(v => v.Category)
            .WithMany(c => c.Videos)
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(v => v.Channel)
            .WithMany(i => i.Videos)
            .HasForeignKey(v => v.ChannelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(v => v.Comments)
            .WithOne(c => c.Video)
            .HasForeignKey(c => c.VideoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(v => v.Likes)
            .WithOne(l => l.Video)
            .HasForeignKey(l => l.VideoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Videos");
    }
}
