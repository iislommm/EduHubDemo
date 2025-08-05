using Application.Dtos;

namespace Application.Services;

public interface IRoleService
{
    Task<long> AddUserAsync(RoleCreateDto roleCreateDto);
    Task<IEnumerable<RoleDto>> GetAllUsersAsync();
    Task<IEnumerable<UserGetDto>> GetAllUsersByRolesNameAsync(string roleName);
    Task DeleteRoleAsync(string deletingRole);
    Task UpdateRoleAsync(RoleUpdateDto roleUpdateDto);
}
