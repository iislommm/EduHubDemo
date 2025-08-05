using CloudinaryDotNet;
using EduHub.Server.Configurations;
using EduHub.Server.Extensions;
using Microsoft.OpenApi.Models;
using Presentation.Endpoints;
using Server.Configurations;
using Server.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDatabase();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();          
builder.ConfigureDependencies();
builder.ConfigureSerilog();
builder.ConfigurationJwtAuth();

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 5242880000; // 50 MB
});
builder.Services.AddSingleton(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var account = new Account(
        config["Cloudinary:CloudName"],
        config["Cloudinary:ApiKey"],
        config["Cloudinary:ApiSecret"]
    );
    return new Cloudinary(account);
});

ServiceCollectionExtensions.AddSwaggerWithJwt(builder.Services);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EduHub API v1");
    options.RoutePrefix = "swagger";
});

app.MapAuthEndpoints();
app.MapCategoryEndpoints();
app.MapCommentEndpoints();
app.MapChannelEndpoints();
app.MapLikeEndpoints();
app.MapRoleEndpoints();
app.MapVideoEndpoints(); 


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
