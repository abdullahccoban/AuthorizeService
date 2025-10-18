using System.Security.Cryptography;
using System.Text;

namespace AuthorizeService;

public class UserDomain
{
    public int Id { get; private set; }
    
    public string Email { get; private set; }

    public string Phone { get; private set; }

    public byte[] PasswordHash { get; private set; }

    public byte[] PasswordSalt { get; private set; }

    public string FullName { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public int RoleId { get; private set; }

    public UserDomain(string email, string phone, string password, string fullName, int role)
    {
        if (string.IsNullOrWhiteSpace(email) || 
            string.IsNullOrWhiteSpace(phone) || 
            string.IsNullOrWhiteSpace(password) || 
            string.IsNullOrWhiteSpace(fullName)) 
            throw new ArgumentException();
        
        Email = email;
        Phone = phone;
        FullName = fullName;
        RoleId = role;
        
        using var hmac = new HMACSHA512();
        PasswordSalt = hmac.Key;
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}
