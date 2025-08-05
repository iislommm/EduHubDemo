using Application.Repositories;
using Core.Errors;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class RoleRepository(AppDbContextPS _context) : IRoleRepository
{

    public async Task<long> InsertUserRoleAsync(Role userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();
        return userRole.RoleId;
    }

    public async Task DeleteUserRoleAsync(Role userRole)
    {
        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Role>> SelectAllRolesAsync()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<ICollection<User>> SelectAllUsersByRoleNameAsync(string userName)
    {
        return await _context.Users.Include(x=>x.Role)
            .Where(u => u.Role != null && u.Role.Name.ToLower() == userName.ToLower())
            .ToListAsync();
    }


    public async Task<Role?> SelectUserRoleByRoleName(string userRoleName)
    {
        return await _context.UserRoles
            .FirstOrDefaultAsync(r => r.Name.ToLower() == userRoleName.ToLower());
    }

    public async Task UpdateUserRoleAsync(Role userRole)
    {
        _context.UserRoles.Update(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task<long> SelectRoleIdByNameAsync(string roleName)
    {
        var role = await _context.UserRoles.FirstOrDefaultAsync(x => x.Name == roleName);
        if (role is null)
        {
            throw new Exception();
        }
        return role.RoleId;
    }

    public async Task<Role> SelectUserRoleByRoleNameAsync(string userRoleName)
    {
        var role = await _context.UserRoles
            .FirstOrDefaultAsync(r => r.Name == userRoleName);

        return role ?? throw new NotFoundException($"Role with name '{userRoleName}' not found.");
    }

}
