namespace Application.Mappers;

public static class LikeMapper
{
    public static Like ToLikeEntity(LikeCreateDto dto)
    {
        return new Like
        {
            UserId = dto.UserId,
            VideoId = dto.VideoId,
            LikedAt = DateTime.UtcNow
        };
    }

    public static LikeDto ToLikeDto(Like like)
    {
        return new LikeDto
        {
            Id = like.Id,
            //UserFirstName = like.User.FirstName,
            LikedAt = like.LikedAt
        };
    }
}
