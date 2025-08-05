using Application.Dtos;
using Application.Mappers;
using Application.Repositories;
using Core.Errors;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.ServiceImplementations;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task<long> AddUserAsync(RoleCreateDto roleCreateDto)
    {
        var userRole = new Role()
        {
            Name = roleCreateDto.Name,
            Description = roleCreateDto.Description
        };

        var userRoleId = await roleRepository.InsertUserRoleAsync(userRole);
        return userRoleId;
    }

    public async Task DeleteRoleAsync(string deletingRole)
    {
        var userRole = await roleRepository.SelectUserRoleByRoleNameAsync(deletingRole);
        await roleRepository.DeleteUserRoleAsync(userRole);
    }

    public async Task<IEnumerable<RoleDto>> GetAllUsersAsync()
    {
        var videos = await roleRepository.SelectAllRolesAsync();
        return videos.Select(RoleMapper.ToRoleDto).ToList();
    }

    public async Task<IEnumerable<UserGetDto>> GetAllUsersByRolesNameAsync(string roleName)
    {
        var users = await roleRepository.SelectAllUsersByRoleNameAsync(roleName);
        return users.Select(UserMapper.ToUserGetDto).ToList();
    }

    public async Task UpdateRoleAsync(RoleUpdateDto roleUpdateDto)
    {
        var userRole = await roleRepository.SelectUserRoleByRoleNameAsync(roleUpdateDto.Name);
        if (userRole is null) throw new NotFoundException($"User role with roleId: {roleUpdateDto.Name} not found");
        else
        {
            userRole.Name = roleUpdateDto.Name;
            userRole.Description = roleUpdateDto.Description;
        }
    }
}
