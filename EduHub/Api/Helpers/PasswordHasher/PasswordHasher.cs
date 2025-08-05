using Org.BouncyCastle.Crypto.Generators;

namespace Application.Helpers.PasswordHasher;


public class PasswordHasher : IPasswordHasher
{
    public (string Hash, string Salt) Hash(string password)
    {
        string salt = Guid.NewGuid().ToString();
        string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
        return (Hash: hash, Salt: salt);
    }

    public bool Verify(string password, string hash, string salt)
    {
        return BCrypt.Net.BCrypt.Verify(password + salt, hash);
    }
}

