namespace Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Video> Videos { get; set; }
}
