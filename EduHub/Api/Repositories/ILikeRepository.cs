using Domain.Entities;

namespace Application.Repositories;

public interface ILikeRepository
{
    Task<long> InsertAsync(Like like);
    Task DeleteAsync(long contentId, long userId);
    Task<IEnumerable<Like>> SelectByVideoIdAsync(long videoId);
    Task<IEnumerable<Like>> SelectByUserIdAsync(long userId);
    Task<Like> SelectLikeByIdAsync(long likeId);
    Task<bool> IsLiked(long userId, long videoId);
}
