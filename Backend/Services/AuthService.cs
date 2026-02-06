using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Service.Interface;
using Backend.Utils;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace Backend.Service;

public class AuthService : IAuthService
{
  private readonly AppDbContext _context;
  private readonly IConfiguration _config;
  public AuthService(AppDbContext context, IConfiguration config)
  {
    _context = context;
    _config = config;
  }
  public async Task<AuthResponse> SignUpAsync(SignUpRequest req, string role = "customer")
  {
    // valid req
    var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
    if (existingUser != null)
      throw new Exception("Email đã tồn tại");

    var emailValidator = new EmailAddressAttribute();
    if (!emailValidator.IsValid(req.Email))
      throw new Exception("Email không hợp lệ");

    if (req.Password != req.ConfirmPassword)
      throw new Exception("Mật khẩu không khớp");

    if (req.Password.Length < 6)
      throw new Exception("Mật khẩu phải có ít nhất 6 kí tự");

    if (req.DisplayName.Equals(string.Empty))
      throw new Exception("Tên hiển thị không được để trống");

    // hash password
    var hashedPassword = BC.HashPassword(req.Password);

    // create new user
    var user = new User
    {
      Email = req.Email,
      PasswordHash = hashedPassword,
      DisplayName = req.DisplayName,
      Role = role,
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    // generate tokens
    var (accessToken, refreshToken, expiresIn) = TokenHelper.GenerateTokens(user, _config);

    // create new refreshToken
    var refreshTokenEntity = new RefreshToken
    {
      UserId = user.Id,
      Token = refreshToken,
      ExpiresAt = DateTime.UtcNow.AddDays(7),
      CreatedAt = DateTime.UtcNow,
      IsRevoked = false
    };

    _context.RefreshTokens.Add(refreshTokenEntity);
    await _context.SaveChangesAsync();

    //  return res
    return new AuthResponse
    {
      UserId = user.Id,
      Email = user.Email,
      DisplayName = user.DisplayName,
      Role = user.Role,
      AccessToken = accessToken,
      RefreshToken = refreshToken,
      ExpiresIn = expiresIn
    };
  }
  public async Task<AuthResponse> SignInAsync(SignInRequest req, string role = "customer")
  {
    // valid req
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
    if (user == null || !BC.Verify(req.Password, user.PasswordHash))
      throw new Exception("Email hoặc mật khẩu không đúng");

    // generate tokens 
    var (accessToken, refreshToken, expiresIn) = TokenHelper.GenerateTokens(user, _config);

    // return res
    return new AuthResponse
    {
      UserId = user.Id,
      Email = user.Email,
      DisplayName = user.DisplayName,
      AccessToken = accessToken,
      RefreshToken = refreshToken,
      ExpiresIn = expiresIn,
      Role = role
    };
  }
  public async Task LogoutAsync(string refreshToken)
  {
    var token = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken && !rt.IsRevoked);

    if (token != null)
    {
      token.IsRevoked = true;
      await _context.SaveChangesAsync();
    }
  }
}