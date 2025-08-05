using Domain.Entities;

public class Comment
{
    public long CommentId { get; set; }

    public string Text { get; set; }

    public DateTime CreatedAt { get; set; }

    public long UserId { get; set; }

    public long VideoId { get; set; }
    public Video Video { get; set; }
}
