namespace Application.Dtos;

public class ChannelDto
{
    public long ChannelId { get; set; }
    public string ChannelName { get; set; }
    public string Bio { get; set; }
    public string ChannelImageUrl { get; set; }
    public string ChannelLink { get; set; }
    public DateTime RegisteredAt { get; set; }
}
