namespace Backend.DTOs;

public class SignUpRequest
{
  public string Email { get; set; } = null!;
  public string Password { get; set; } = null!;
  public string ConfirmPassword { get; set; } = null!;
  public string DisplayName { get; set; } = null!;
}

public class SignInRequest
{
  public string Email { get; set; } = null!;
  public string Password { get; set; } = null!;
}

public class AuthResponse
{
  public int UserId { get; set; }
  public string Email { get; set; } = null!;
  public string DisplayName { get; set; } = null!;
  public string Role { get; set; } = null!;
  public string AccessToken { get; set; } = null!;
  public string RefreshToken { get; set; } = null!;
  public DateTime ExpiresIn { get; set; }
}

public class LogoutRequest
{
  public string RefreshToken { get; set; } = null!;
}