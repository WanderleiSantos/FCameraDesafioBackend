namespace FCameraDesafioBackend.Application.Shared.Extensions;

public static class EncryptExtension
{
    public static string HashPassword(this string input)
    {
        return BCrypt.Net.BCrypt.HashPassword(input);
    }

    public static bool VerifyPassword(this string input, string verify)
    {
        return BCrypt.Net.BCrypt.Verify(input, verify);
    }
}