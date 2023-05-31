using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class BcryptPasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return hashedPassword;
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        bool passwordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        return passwordValid;
    }
}