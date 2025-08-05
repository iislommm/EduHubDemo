namespace Application.Dtos.Comment;

public class CommentCreateDto
{
    public long UserId { get; set; }
    public long VideoId { get; set; }
    public string Text { get; set; }
}
