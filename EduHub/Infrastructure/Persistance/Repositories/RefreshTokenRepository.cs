using Application.Repositories;
using Core.Errors;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace Infrastructure.Persistance.Repositories;

public class RefreshTokenRepository(AppDbContextPS appDbContext) : IRefreshTokenRepository
{
    public async Task InsertRefreshTokenAsync(RefreshToken refreshToken)
    {
        await appDbContext.RefreshTokens.AddAsync(refreshToken);
        await appDbContext.SaveChangesAsync();
    }

    public async Task RemoveRefreshTokenAsync(string token)
    {
        var refreshToken = await appDbContext.RefreshTokens.FirstOrDefaultAsync(rf => rf.Token == token);
        if (refreshToken is null) return;

        refreshToken.IsRevoked = true;
        appDbContext.RefreshTokens.Update(refreshToken);
        await appDbContext.SaveChangesAsync();
    }


    public async Task<RefreshToken?> SelectActiveTokenByUserIdAsync(long userId)
    {
        RefreshToken? refreshToken;
        try
        {
            refreshToken = await appDbContext.RefreshTokens
            .Include(rf => rf.User)
            .SingleOrDefaultAsync(rf => rf.UserId == userId && rf.IsRevoked == false && rf.Expires > DateTime.UtcNow);
        }
        catch (InvalidOperationException ex)
        {
            throw new Exception($"2 or more active refreshToken found with userId: {userId} found!\nAnd {ex.Message}");
        }
        return refreshToken;
    }

    public async Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId)
    {
        var refToken = await appDbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.UserId == userId);
        return refToken ?? throw new InvalidArgumentException($"RefreshToken with {userId} is invalid");
    }
}
