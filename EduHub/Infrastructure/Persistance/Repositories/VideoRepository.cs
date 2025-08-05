using Application.Repositories;
using Core.Errors;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class VideoRepository(AppDbContextMS appDbContext) : IVideoRepository
{
    private readonly AppDbContextMS _context = appDbContext;

    public async Task<long> InsertAsync(Video video)
    {
        await _context.Videos.AddAsync(video);
        await _context.SaveChangesAsync();
        return video.VideoId;
    }

    public async Task UpdateAsync(Video video)
    {
        var existing = await _context.Videos.FindAsync(video.VideoId);
        if (existing is null)
            throw new Exception("Video not found");
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long videoId)
    {
        var video = await _context.Videos.FindAsync(videoId);
        if (video is null)
            throw new NotFoundException("Video not found");

        _context.Videos.Remove(video);
        await _context.SaveChangesAsync();
    }

    public async Task<Video> SelectVideoByIdAsync(long videoId)
    {

        var video = await _context.Videos.Include(x => x.Comments).Include(x => x.Channel).Include(x => x.Category).FirstOrDefaultAsync(x=>x.VideoId == videoId);
        if (video is null)
            throw new NotFoundException($"Video #{videoId} not found");

        return video;
    }

    public async Task<Video> SelectVideoByNameAsync(string name)
    {
        var video = await _context.Videos
            .FirstOrDefaultAsync(v => v.Name.ToLower() == name.ToLower());

        if (video is null)
            throw new NotFoundException($"{name} named video not found");

        return video;
    }

    public async Task<IEnumerable<Video>> SelectAllVideosAsync()
    {
        return await _context.Videos.Include(x=>x.Comments).Include(x=>x.Channel).Include(x=>x.Category).ToListAsync();
    }

    public async Task<IEnumerable<Video>> SelectVideosByCategoryIdAsync(long categoryId)
    {
        return await _context.Videos.Include(x => x.Comments).Include(x => x.Channel).Include(x => x.Category)
            .Where(v => v.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Video>> SelectVideoByInstructorIdAsync(int instructorId)
    {
        return await _context.Videos
            .Where(v => v.ChannelId == instructorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Video>> SelectVideosByPriceAsync(decimal price)
    {
        return await _context.Videos
            .Where(v => v.Price == price)
            .ToListAsync();
    }

    public async Task<IEnumerable<Video>> SelectVideosBetweemPriceAsyncn(decimal minPrice, decimal maxPrice)
    {
        return await _context.Videos
            .Where(v => v.Price >= minPrice && v.Price <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<Video>> SelectWithCategoryAsync()
    {
        return await _context.Videos
            .Include(v => v.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Video>> SelectVideoWithInstructorAsync()
    {
        return await _context.Videos
            .Include(v => v.Channel)
            .ToListAsync();
    }

    public async Task IncrementViewsAsync(long videoId)
    {
        var video = await _context.Videos.FindAsync(videoId);
        if (video is null)
            throw new NotFoundException($"Video #{videoId} not found");

        video.Views++;
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<Video>> SelectVideoByInstructorIdAsync(long instructorId)
    {
        throw new NotImplementedException();
    }
}
