using Domain.Entities;

namespace Application.Repositories;

public interface ICommentRepository
{
    Task<long> InsertCommentAsync(Comment comment);
    Task DeleteCommentAsync(long commentId);
    Task<IEnumerable<Comment>> SelectCommentByVideoIdAsync(long videoId);
    Task<IEnumerable<Comment>> SelectCommentByUserIdAsync(long userId);
    Task<Comment?> SelectCommentByIdAsync(long commentId);
  
}
