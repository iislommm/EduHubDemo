using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InstructorConfiguration : IEntityTypeConfiguration<Channel>
{
    public void Configure(EntityTypeBuilder<Channel> builder)
    {

        builder.HasKey(i => i.ChannelId);

        builder.Property(i => i.ChannelName)
            .IsRequired()
            .HasMaxLength(100);

        //builder.Property(i => i.Email)
        //    .IsRequired()
        //    .HasMaxLength(150);

        builder.Property(i => i.Bio)
            .HasMaxLength(1000); 

        builder.Property(i => i.ChannelImageUrl)
            .HasMaxLength(255);

        builder.Property(i => i.ChannelLink)
            .HasMaxLength(255);

        builder.Property(i => i.RegisteredAt)
            .IsRequired();

        builder.HasMany(i => i.Videos)
            .WithOne(v => v.Channel)
            .HasForeignKey(v => v.ChannelId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.ToTable("Instructors");
    }
}
