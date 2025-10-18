using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        try
        {
            await _authService.RegisterAsync(request);
            return Ok();            
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request) 
    {
        try
        {
            LoginResponseDto response = await _authService.LoginAsync(request);
            return Ok(response);
        }
        catch (Exception)
        {
            return Unauthorized();
        }
    }

}
