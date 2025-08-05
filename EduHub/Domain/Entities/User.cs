using Domain.Entities;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public int Age { get; set; }

    public long RoleId { get; set; }
    public Role Role { get; set; }  
    public long InstructorId { get; set; } 
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}
