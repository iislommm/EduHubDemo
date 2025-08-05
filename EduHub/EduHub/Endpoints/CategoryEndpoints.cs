using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/categories")
                       .WithTags("Categories");

        group.MapGet("/", async ([FromServices] ICategoryService service) =>
        {
            var result = await service.GetAllCatigoriesAsync();
            return Results.Ok(result);
        });

        group.MapGet("/{name}", async (string name, [FromServices] ICategoryService service) =>
        {
            var result = await service.GetCategoryByNameAsync(name);
            return Results.Ok(result);
        });

        group.MapPost("/", async ([FromBody] CategoryCreateDto dto, [FromServices] ICategoryService service) =>
        {
            var id = await service.AddCategoryAsync(dto);
            return Results.Created($"/api/categories/{id}", new { Id = id });
        });

        group.MapPut("/{id:long}", async (
            long id,
            [FromBody] CategoryUpdateDto dto,
            [FromServices] ICategoryService service) =>
        {
            await service.UpdateCategoryAsync(dto, id);
            return Results.NoContent();
        });

        group.MapDelete("/{id:long}", async (long id, [FromServices] ICategoryService service) =>
        {
            await service.DeleteCategoryAsync(id);
            return Results.NoContent();
        });
    }
}
