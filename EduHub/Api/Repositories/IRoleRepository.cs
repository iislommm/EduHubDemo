using Domain.Entities;

namespace Application.Repositories;

public interface IRoleRepository
{
    Task<ICollection<Role>> SelectAllRolesAsync();
    Task<ICollection<User>> SelectAllUsersByRoleNameAsync(string roleName);
    Task<Role> SelectUserRoleByRoleNameAsync(string userRoleName);
    Task<long> InsertUserRoleAsync(Role userRole);
    Task<long> SelectRoleIdByNameAsync(string roleName);
    Task DeleteUserRoleAsync(Role userRole);
    Task UpdateUserRoleAsync(Role userRole);    
}
