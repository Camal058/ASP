using LoginRegistration.Models;
using System.Security.Cryptography;
using System.Text;

namespace LoginRegistration;

public class UserRepository
{
    private static List<User> _users = new List<User>();

    public static bool RegisterUser(User user)
    {
        if (_users.Any(u => u.Username == user.Username))
        {
            return false; // Username already exists
        }

        user.PasswordHash = HashPassword(user.PasswordHash);
        _users.Add(user);
        return true;
    }

    public static bool AuthenticateUser(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);

        if (user != null)
        {
            string hashedPassword = HashPassword(password);
            return string.Equals(hashedPassword, user.PasswordHash, StringComparison.OrdinalIgnoreCase);
        }
        else
        {
            return false;
        }
    }

    private static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}