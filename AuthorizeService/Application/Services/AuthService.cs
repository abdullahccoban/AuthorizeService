using System.Security.Cryptography;
using System.Text;
using AuthorizeService.Infrastructure.Context;
using AutoMapper;

namespace AuthorizeService;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repo;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public AuthService(IAuthRepository repo, IMapper mapper, IConfiguration config)
    {
        _repo = repo;        
        _mapper = mapper;
        _config = config;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        var user = request.Email != null ? await _repo.GetByEmailAsync(request.Email) : (request.Phone != null ? await _repo.GetByPhoneAsync(request.Phone) : throw new Exception());

        if(user == null) throw new Exception();

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        
        if(!computedHash.SequenceEqual(user.PasswordHash)) throw new Exception();

        return new LoginResponseDto {
            AccessToken = JWTHelper.GenerateJwtToken(user.Email, user.Phone, user.FullName, user.Role.Role1, _config)
        };
    }

    public async Task RegisterAsync(RegisterRequestDto request) 
    {
        var role = await _repo.GetDefaultProjectRole(request.ProjectId);

        if (role == null) throw new Exception();

        var user = new UserDomain(request.Email, request.Phone, request.Password, request.FullName, role!.Id);

        if(await _repo.GetByEmailAsync(user.Email) != null)
            throw new Exception("User exists!");

        await _repo.AddAsync(_mapper.Map<User>(user));
    }
}
