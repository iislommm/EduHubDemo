namespace Application.Abstractions.Services;

public interface ILikeService
{
    Task<long> AddLikeAsync(LikeCreateDto dto);
    Task DeleteLikeAsync(long contentId, long userId);
    Task<IEnumerable<LikeDto>> GetLikesByVideoIdAsync(long videoId);
    Task<bool> HasUserLikedAsync(long userId, long videoId);
}
