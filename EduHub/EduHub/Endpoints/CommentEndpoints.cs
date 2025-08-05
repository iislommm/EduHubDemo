using Application.Dtos.Comment;
using Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Server.Endpoints;

public static class CommentEndpoints
{
    public static void MapCommentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/comments")
                       .WithTags("Comments");

        
        group.MapPost("/", async (
            [FromBody] CommentCreateDto dto,
            [FromServices] ICommentService service) =>
        {
            var id = await service.AddCommentAsync(dto);
            return Results.Created($"/api/comments/{id}", new { Id = id });
        });

        group.MapGet("/video/{videoId:long}", async (
            long videoId,
            [FromServices] ICommentService service) =>
        {
            var comments = await service.GetCommentsByVideoIdAsync(videoId);
            return Results.Ok(comments);
        });

        group.MapDelete("/{commentId:long}", async (
            long commentId,
            [FromServices] ICommentService service) =>
        {
            await service.DeleteCommentAsync(commentId);
            return Results.NoContent();
        });
    }
}
