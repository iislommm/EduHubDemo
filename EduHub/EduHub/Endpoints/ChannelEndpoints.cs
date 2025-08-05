using Application.Dtos;
using Application.Services;
using CloudinaryDotNet.Actions;
using Core.Core.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Endpoints;

public static class ChannelEndpoints
{
    public static void MapChannelEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/channels")
                       .WithTags("Channels");

        group.MapPost("/", async (
            [FromBody] ChannelCreateDto dto,
            [FromServices] IChannelService service,HttpContext context) =>
        {
            var userId = context.User.FindFirst("UserId")?.Value;
            if (userId is null)
            {
                throw new UnauthorizedException();
            }
            var id = await service.AddChannelAsync(dto,long.Parse(userId));
            return Results.Created($"/api/channels/{id}", new { Id = id });
        });

        group.MapGet("/", async (
            [FromServices] IChannelService service,HttpContext context) =>
        {
            var userId = context.User.FindFirst("UserId")?.Value;
            if(userId is null)
            {
                throw new UnauthorizedException();
            }
            var result = await service.GetAllChannelsAsync(long.Parse(userId));
            return Results.Ok(result);
        });

        group.MapGet("/by-link/{link}", async (
            string link,
            [FromServices] IChannelService service) =>
        {
            var result = await service.GetChennelByLinkAsync(link);
            return Results.Ok(result);
        });

        group.MapPut("/{id:long}", async (
            long id,
            [FromBody] ChannelUpdateDto dto,
            [FromServices] IChannelService service) =>
        {
            await service.UpdateChannelAsync(dto, id);
            return Results.NoContent();
        });

        group.MapDelete("/{id:long}", async (
            long id,
            [FromServices] IChannelService service) =>
        {
            await service.DeleteChannelAsync(id);
            return Results.NoContent();
        });
    }
}
