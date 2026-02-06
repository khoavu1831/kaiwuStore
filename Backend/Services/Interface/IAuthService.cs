using Backend.DTOs;

namespace Backend.Service.Interface;

public interface IAuthService
{
  Task<AuthResponse> SignUpAsync(SignUpRequest req, string role = "customer");
  Task<AuthResponse> SignInAsync(SignInRequest req, string role = "customer");
  Task LogoutAsync(string refreshToken);
}