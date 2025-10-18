using AuthorizeService.Infrastructure.Context;

namespace AuthorizeService;

public interface IAuthRepository
{
    Task<User> AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByPhoneAsync(string phone);
    Task<Role?> GetDefaultProjectRole(int projectId);
}
