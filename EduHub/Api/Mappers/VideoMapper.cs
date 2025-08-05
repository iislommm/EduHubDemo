using Domain.Entities;

namespace Application.Mappers;

public static class VideoMapper
{
    public static Video ToVideoEntity(VideoCreateDto dto)
    {
        return new Video
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            ChannelId = dto.InstructorId
        };
    }

    public static VideoGetDto ToVideoGetDto(Video video)
    {
        return new VideoGetDto
        {
            VideoId = video.VideoId,
            Name = video.Name,
            Description = video.Description,
            MB = video.MB,
            Price = video.Price,
            Views = video.Views,
            Duration = video.Duration,
            VideoUrl = video.VideoUrl,
            Category = video.Category.Name,
            Comments = video.Comments.Select(CommentMapper.ToCommentDto).ToList(),
            ChannelName = video.Channel.ChannelName
        };
    }

    public static void UpdateEntity(Video video, VideoUpdateDto dto)
    {
        video.Name = dto.Name;
        video.Description = dto.Description;
        video.Price = dto.Price;
    }
}
