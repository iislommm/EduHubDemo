using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class AppDbContextPS : DbContext
{
    public AppDbContextPS(DbContextOptions<AppDbContextPS> options)
     : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> UserRoles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
       typeof(AppDbContextPS).Assembly,
       t => t.Namespace == "Infrastructure.ConfigurationsPS"
   );
    }

}
