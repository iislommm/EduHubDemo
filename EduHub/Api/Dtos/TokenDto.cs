namespace Application.Dtos;

public class TokenDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpireAt { get; set; }
}
