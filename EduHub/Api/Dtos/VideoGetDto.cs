public class VideoGetDto
{
    public long VideoId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public decimal Price { get; set; }
    public int Views { get; set; }
    public TimeSpan Duration { get; set; }
    public List<CommentDto> Comments { get; set; } 
    public string VideoUrl { get; set; }
    public string Category { get; set; } 
    public string ChannelName { get; set; }
}
    