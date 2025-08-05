using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Helpers;
using Application.Helpers.PasswordHasher;
using Application.Repositories;
using Application.ServiceContracts;
using Application.ServiceContracts.ServiceImplementations;
using Application.Services;
using Application.Services.ServiceImplementations;
using CloudinaryDotNet;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Persistence.Repositories;

namespace Server.Configurations;

public static class DIConfiguration
{
    public static void ConfigureDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
        builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        builder.Services.AddScoped<ILikeRepository, LikeRepository>();
        builder.Services.AddScoped<IVideoRepository, VideoRepository>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IChannelService, ChannelSerevice>();
        builder.Services.AddScoped<ILikeService, LikeService>();
        builder.Services.AddScoped<IVideoService, VideoService>();
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddSingleton<Cloudinary>();


    }
}