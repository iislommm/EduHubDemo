using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Endpoints;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/roles").WithTags("Roles").RequireAuthorization();
        group.MapGet("/",  async (IRoleService service) =>
        {
            var result = await service.GetAllUsersAsync();
            return Results.Ok(result);
        });

        group.MapGet("/{roleName}/users", async (string roleName, IRoleService service) =>
        {
            var result = await service.GetAllUsersByRolesNameAsync(roleName);
            return Results.Ok(result);
        });

        group.MapPost("/", async (RoleCreateDto dto, HttpContext context, IRoleService service) =>
        {
            var id = await service.AddUserAsync(dto);
            return Results.Ok(new { Id = id });
        });

        group.MapDelete("/{deletingRole}", async (string deletingRole, HttpContext context, IRoleService service) =>
        {
            await service.DeleteRoleAsync(deletingRole);
            return Results.NoContent();
        });

        group.MapPut("/", async (RoleUpdateDto dto, IRoleService service) =>
        {
            await service.UpdateRoleAsync(dto);
            return Results.NoContent();
        });
    }
}
