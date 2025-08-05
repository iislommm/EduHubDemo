using Application.Abstractions.Repositories;
using Application.Dtos.Comment;
using Application.Repositories;
using Core.Errors;
using Application.Mappers;

namespace Application.ServiceContracts.ServiceImplementations;

public class CommentService(
    ICommentRepository commentRepository,
    IUserRepository userRepository,
    IVideoRepository videoRepository) : ICommentService
{
    public async Task<long> AddCommentAsync(CommentCreateDto dto)
    {
        var user = await userRepository.SelectUserByIdAsync(dto.UserId)
                   ?? throw new NotFoundException("User not found.");

        var video = await videoRepository.SelectVideoByIdAsync(dto.VideoId)
                    ?? throw new NotFoundException("Video not found.");

        var comment = new Comment
        {
            Text = dto.Text,
            UserId = dto.UserId,
            VideoId = dto.VideoId,
            CreatedAt = DateTime.UtcNow
        };

        return await commentRepository.InsertCommentAsync(comment);
    }
        
    public async Task<IEnumerable<CommentDto>> GetCommentsByVideoIdAsync(long videoId)
    {
        var comments = await commentRepository.SelectCommentByVideoIdAsync(videoId);
        return comments.Select(CommentMapper.ToCommentDto).ToList();
    }

    public async Task DeleteCommentAsync(long commentId)
    {
        var comment = await commentRepository.SelectCommentByIdAsync(commentId)
            ?? throw new NotFoundException($"Cmment with {commentId} not found");
         await commentRepository.DeleteCommentAsync(commentId);
            
    }
}
