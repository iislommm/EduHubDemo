using Application.Abstractions.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContextPS appDbContext) : IUserRepository
{
    public async Task DeleteUserById(long userId)
    {
        var user = await SelectUserByIdAsync(userId);
        appDbContext.Users.Remove(user);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await appDbContext.Users.ToListAsync();
    }
    public async Task<User?> SelectByEmailAsync(string email)
    {
        return await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<long> InsertUserAsync(User user)
    {
        await appDbContext.Users.AddAsync(user);
        await appDbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<User?> SelectUserByIdAsync(long id)
    {
        var user = await appDbContext.Users
            .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.Id == id); 

        if (user is null)
            throw new Exception($"User with ID {user.Id} not found");

        return user;
    }

    public async Task<User?> SelectUserByUserNameAsync(string userName)
    {
        var user = await appDbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserName == userName);

        if (user is null)
            throw new Exception($"User with {userName} not found");
        return user;
        
    }

    public async Task UpdateUserRoleAsync(long userId, long userRoleId)
    {
        var user = await SelectUserByIdAsync(userId);
        user.RoleId = userRoleId;
        appDbContext.Users.Update(user);
        await appDbContext.SaveChangesAsync();
    }
}
