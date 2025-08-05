using Application.Dtos.Comment;

namespace Application.ServiceContracts;

public interface ICommentService
{
    Task<long> AddCommentAsync(CommentCreateDto dto);
    Task<IEnumerable<CommentDto>> GetCommentsByVideoIdAsync(long videoId);
    Task DeleteCommentAsync(long commentId);
}
