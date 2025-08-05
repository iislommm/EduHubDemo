using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class AppDbContextMS : DbContext
{
    public AppDbContextMS(DbContextOptions<AppDbContextMS> options)
     : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
       typeof(AppDbContextMS).Assembly,
       t => t.Namespace == "Infrastructure.ConfigurationsMS"
   );
    }
}
