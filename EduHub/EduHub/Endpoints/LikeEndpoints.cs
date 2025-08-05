using Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Endpoints;

public static class LikeEndpoints
{
    public static void MapLikeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/likes")
                       .WithTags("Likes");

        group.MapPost("/", async (
            [FromBody] LikeCreateDto dto,
            [FromServices] ILikeService service) =>
        {
            var id = await service.AddLikeAsync(dto);
            return Results.Created($"/api/likes/{id}", new { Id = id });
        });

        group.MapGet("/video/{videoId:long}", async (
            long videoId,
            [FromServices] ILikeService service) =>
        {
            var likes = await service.GetLikesByVideoIdAsync(videoId);
            return Results.Ok(likes);
        });

        group.MapDelete("/", async (
            [FromQuery] long videoId,
            [FromQuery] long userId,
            [FromServices] ILikeService service) =>
        {
            await service.DeleteLikeAsync(videoId, userId);
            return Results.NoContent();
        });

        group.MapGet("/is-liked", async (
            [FromQuery] long videoId,
            [FromQuery] long userId,
            [FromServices] ILikeService service) =>
        {
            var result = await service.HasUserLikedAsync(userId, videoId);
            return Results.Ok(result);
        });
    }
}
