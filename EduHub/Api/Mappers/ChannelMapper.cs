using Application.Dtos;

namespace Application.Mappers;

public static class ChannelMapper
{
    public static Channel ToInstructorEntity(ChannelCreateDto dto)
    {
        return new Channel
        {
            ChannelName = dto.ChannelName,
            Bio = dto.Bio,
            ChannelImageUrl = dto.ChannelImageUrl,
            ChannelLink = dto.ChannelLink,
            RegisteredAt = DateTime.UtcNow,
        };
    }

    public static ChannelDto ToChannelDto(Channel instructor)
    {
        return new ChannelDto
        {
            ChannelId = instructor.ChannelId,
            ChannelName = instructor.ChannelName,
            Bio = instructor.Bio,
            ChannelImageUrl = instructor.ChannelImageUrl,
            ChannelLink = instructor.ChannelLink,
            RegisteredAt = instructor.RegisteredAt,             
        };
    }

    public static void UpdateEntity(Channel instructor, ChannelUpdateDto dto)
    {
        instructor.ChannelName = dto.ChannelName;
        instructor.Bio = dto.Bio;
        instructor.ChannelImageUrl = dto.ProfileImageUrl;
    }
}
