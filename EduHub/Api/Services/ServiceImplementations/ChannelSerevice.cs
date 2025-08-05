using Application.Dtos;
using Application.Mappers;
using Application.Repositories;
using Core.Errors;

namespace Application.Services.ServiceImplementations;

public class ChannelSerevice (
    IChannelRepository channelRepository,
    IVideoRepository videoRepository): IChannelService
{
    public async Task<long> AddChannelAsync(ChannelCreateDto channelCreateDto,long userId)
    {
        var channel = new Channel()
        {
            ChannelName = channelCreateDto.ChannelName,
            Bio = channelCreateDto.Bio,
            ChannelImageUrl = channelCreateDto.ChannelImageUrl,
            ChannelLink = channelCreateDto.ChannelLink,
            CreatorId = userId
        };
        return await channelRepository.InsertAsync(channel);
    }

    public async Task DeleteChannelAsync(long channelId)
    {
        var channel  = await channelRepository.SelectByIdAsync(channelId)
            ?? throw new NotFoundException($"channel with id {channelId} not found");
        await channelRepository.DeleteAsync(channelId);
    }

    public async Task<IEnumerable<ChannelDto>> GetAllChannelsAsync(long useerId)
    {
        var channels = await channelRepository.SelectAllAsync(useerId);
        return channels.Select(ChannelMapper.ToChannelDto).ToList();
    }

    public async Task<ChannelDto> GetChennelByLinkAsync(string channelLink)
    {
        var channel = await channelRepository.SelectByLinkAsync(channelLink);
        if (channel is null) throw new NotFoundException($"Channel with {channelLink} not found");

        return ChannelMapper.ToChannelDto(channel);
    }

    public async Task UpdateChannelAsync(ChannelUpdateDto channelUpdateDto, long channelId)
    {
        var updatingChannel = await channelRepository.SelectByIdAsync(channelId);

        if (updatingChannel is null) throw new NotFoundException($"channel with id : {channelId} not found");

        else
        {
            updatingChannel.ChannelName = channelUpdateDto.ChannelName;
            updatingChannel.Bio = channelUpdateDto.Bio;
            updatingChannel.ChannelImageUrl = channelUpdateDto.ProfileImageUrl;
            await channelRepository.UpdateAsync(updatingChannel);
        }
    }
}
