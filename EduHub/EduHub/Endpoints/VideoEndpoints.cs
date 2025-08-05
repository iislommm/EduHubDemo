using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Endpoints;

public static class VideoEndpoints
{
    public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/videos")
                       .WithTags("Videos");

        group.MapGet("/", async ([FromServices] IVideoService service) =>
        {
            var result = await service.GetAllVideosAsync();
            return Results.Ok(result);
        });

        group.MapGet("/{id:long}", async (long id, [FromServices] IVideoService service) =>
        {
            var result = await service.GetVideoByIdAsync(id);
            return Results.Ok(result);
        });

        group.MapGet("/instructor/{instructorId:long}", async (long instructorId, [FromServices] IVideoService service) =>
        {
            var result = await service.GetVideosByInstructorAsync(instructorId);
            return Results.Ok(result);
        });

        group.MapGet("/category/{categoryId:long}", async (long categoryId, [FromServices] IVideoService service) =>
        {
            var result = await service.GetVideosByCateforyIdAsync(categoryId);
            return Results.Ok(result);
        });

        group.MapPost("/", async ([FromForm] VideoCreateDto dto, IFormFile file, [FromServices] IVideoService service) =>
        {
            var id = await service.AddVideoAsync(dto,file);
            return Results.Created($"/api/videos/{id}", new { Id = id });
        }).DisableAntiforgery(); ;

        group.MapPut("/{id:long}", async (long id, [FromBody] VideoUpdateDto dto, [FromServices] IVideoService service) =>
        {
            await service.UpdateVideoasync(id, dto);
            return Results.NoContent();
        }).DisableAntiforgery();

        group.MapDelete("/{id:long}", async (long id, [FromServices] IVideoService service) =>
        {
            await service.DeleteVideoAsync(id);
            return Results.NoContent();
        });
    }
}
