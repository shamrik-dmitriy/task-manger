using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TM.Application.Interfaces.Infrastructure;

namespace TM.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public byte[] GenerateSalt()
    {
        var salt = new byte[32];
        using var rnd = RandomNumberGenerator.Create();
        rnd.GetBytes(salt);
        return salt;
    }

    public byte[] HashPassword(string password, byte[] salt)
    {
        using var sha256 = SHA256.Create();
        var combined = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        return sha256.ComputeHash(combined);
    }
}