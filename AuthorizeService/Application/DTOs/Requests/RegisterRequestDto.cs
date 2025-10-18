namespace AuthorizeService;

public class RegisterRequestDto
{
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public required string FullName { get; set; } 
    public int ProjectId { get; set; }
}
