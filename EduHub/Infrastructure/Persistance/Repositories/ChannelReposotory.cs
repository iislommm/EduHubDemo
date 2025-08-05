using Application.Repositories;
using Core.Errors;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class ChannelRepository(AppDbContextMS context) : IChannelRepository
{
    public async Task<long> InsertAsync(Channel instructor)
    {
        await context.Channels.AddAsync(instructor);
        await context.SaveChangesAsync();
        return instructor.ChannelId;
    }

    public async Task UpdateAsync(Channel channel)
    {
        var existing = await context.Channels.FindAsync(channel.ChannelId);
        if (existing is null)
            throw new NotFoundException("Instructor not found");

        existing.ChannelName = channel.ChannelName;
        existing.Bio = channel.Bio;
        existing.ChannelImageUrl = channel.ChannelImageUrl;
        existing.ChannelLink = channel.ChannelLink;
        existing.CreatorId = channel.CreatorId;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long channelId)
    {
        var channel = await context.Channels.FindAsync(channelId);
        if (channel is null)
            throw new NotFoundException("Channel not found");

        context.Channels.Remove(channel);
        await context.SaveChangesAsync();
    }

    public async Task<Channel?> SelectByIdAsync(long instructorId)
    {
        return await context.Channels.FindAsync(instructorId);
    }

    public async Task<Channel?> SelectByLinkAsync(string link)
    {
        return await context.Channels
            .FirstOrDefaultAsync(i => i.ChannelLink.ToLower() == link.ToLower());
    }

    public async Task<IEnumerable<Channel>> SelectAllAsync(long userId)
    {
        return await context.Channels.Where(x => x.CreatorId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Channel>> SelectWithVideosAsync()
    {
        return await context.Channels
            .Include(i => i.Videos)
            .ToListAsync();
    }
}
