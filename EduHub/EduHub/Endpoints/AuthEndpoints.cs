using Application.Dtos;
using Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Server.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth");

        group.MapPost("/register", SignUpAsync);
        group.MapPost("/login", LoginAsync);
        group.MapPost("/refresh", RefreshTokenAsync);
        group.MapPost("/logout", LogoutAsync);
    }

    private static async Task<IResult> SignUpAsync(SignUpDto dto, IAuthService authService)
    {
        var userId = await authService.SignUpUserAsync(dto);
        return Results.Ok(new { Message = "User created", UserId = userId });
    }

    private static async Task<IResult> LoginAsync(UserLoginDto dto, IAuthService authService)
    {
        var response = await authService.LoginUserAsync(dto);
        return Results.Ok(response);
    }

    private static async Task<IResult> RefreshTokenAsync(RefreshRequestDto dto, IAuthService authService)
    {
        var response = await authService.RefreshTokenAsync(dto);
        return Results.Ok(response);
    }

    private static async Task<IResult> LogoutAsync(string refreshToken, IAuthService authService)
    {
        await authService.LogoutAsync(refreshToken);
        return Results.Ok(new { Message = "Logged out" });
    }
}
