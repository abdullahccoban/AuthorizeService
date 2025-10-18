using AuthorizeService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthorizeService;

public class AuthRepository : IAuthRepository
{
    private readonly AuthDbContext _context;
    
    public AuthRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByEmailAsync(string email) => await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User?> GetByPhoneAsync(string phone) => await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Phone == phone);

    public async Task<Role?> GetDefaultProjectRole(int projectId) => await _context.Roles.FirstOrDefaultAsync(r => r.ProjectId == projectId && r.IsDefault == true);



}
