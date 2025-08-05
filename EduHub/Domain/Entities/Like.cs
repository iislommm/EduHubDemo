using Domain.Entities;

public class Like
{
    public long Id { get; set; }
    public long UserId { get; set; }

    public long VideoId { get; set; }
    public Video Video { get; set; }

    public DateTime LikedAt { get; set; }
}
