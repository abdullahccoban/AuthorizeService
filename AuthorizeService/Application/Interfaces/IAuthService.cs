namespace AuthorizeService;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task RegisterAsync(RegisterRequestDto request);
}
