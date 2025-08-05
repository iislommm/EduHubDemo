using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace EduHub.Server.Configurations;

public static class DataBaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionStringMS = builder.Configuration.GetConnectionString("DatabaseConnectionMS");

        builder.Services.AddDbContext<AppDbContextMS>(options => options.UseSqlServer(connectionStringMS));


        var connectionStringPS = builder.Configuration.GetConnectionString("DatabaseConnectionPS");

        builder.Services.AddDbContext<AppDbContextPS>(options => options.UseNpgsql(connectionStringPS));


    }





}
