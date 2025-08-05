using Application.Dtos;

namespace Application.Services;

public interface IChannelService
{
    Task<long> AddChannelAsync(ChannelCreateDto channelCreateDto,long userId);
    Task DeleteChannelAsync(long channelId);
    Task<ChannelDto> GetChennelByLinkAsync(string channelLink);
    Task UpdateChannelAsync(ChannelUpdateDto channelUpdateDto, long channelId);
    Task<IEnumerable<ChannelDto>> GetAllChannelsAsync(long userId);
}
