using Domain.Entities;

public class Channel
{
    public long ChannelId { get; set; }
    public string ChannelName { get; set; }
    public string Bio { get; set; }
    public string ChannelImageUrl { get; set; }
    public string ChannelLink { get; set; }
    public DateTime RegisteredAt { get; set; }
    public ICollection<Video> Videos { get; set; }
    public long CreatorId { get; set; }
}
