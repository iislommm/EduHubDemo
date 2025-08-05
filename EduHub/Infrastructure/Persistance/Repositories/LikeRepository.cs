using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Core.Errors;
using Azure.Identity;

namespace Infrastructure.Persistance.Repositories;

public class LikeRepository(AppDbContextMS context) : ILikeRepository
{
    public async Task<long> InsertAsync(Like like)
    {
        await context.Likes.AddAsync(like);
        await context.SaveChangesAsync();
        return like.Id;
    }

    public async Task DeleteAsync(long contentId, long userId)
    {
        var like = await context.Likes.FirstOrDefaultAsync(x=>x.VideoId == contentId && x.UserId == userId);
        if (like is null) return;
        context.Likes.Remove(like);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Like>> SelectByVideoIdAsync(long videoId)
    {
        return await context.Likes
            .Where(l => l.VideoId == videoId)
            //.Include(l => l.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Like>> SelectByUserIdAsync(long userId)
    {
        return await context.Likes
            .Where(l => l.UserId == userId)
            .Include(l => l.Video)
            .ToListAsync();
    }
    public async Task<Like?> SelectLikeByIdAsync(long likeId)
    {
        return await context.Likes
            .FirstOrDefaultAsync(like => like.Id == likeId);
    }

    public async Task<List<Video>> GetLikesByUserId(long userId)
    {
        List<Like> likes =await context.Likes.Include(x=>x.Video).Where(x => x.UserId == userId).ToListAsync();
        return likes.Select(x => x.Video).ToList();

    }

    public async Task<bool> IsLiked(long userId,long videoId)
    {
        return await context.Likes.AnyAsync(x => x.UserId == userId && x.VideoId == videoId);
    }
}
