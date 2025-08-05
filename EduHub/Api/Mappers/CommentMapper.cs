using Application.Abstractions.Repositories;
using Application.Dtos.Comment;
using Domain.Entities;

namespace Application.Mappers;

public static class CommentMapper
{
    public static Comment ToCommentEntity(CommentCreateDto dto)
    {
        return new Comment
        {
            UserId = dto.UserId,
            VideoId = dto.VideoId,
            Text = dto.Text,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static CommentDto ToCommentDto(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.CommentId,
            //UserFirstName = comment.User.FirstName,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt,
            VideoId = comment.VideoId
        };
    }
}
