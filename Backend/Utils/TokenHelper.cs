using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Utils;

public static class TokenHelper
{
  public static string GenerateRandomToken()
  {
    var randomNumber = new byte[32];
    using var rng = RandomNumberGenerator.Create();
    rng.GetBytes(randomNumber);
    return Convert.ToBase64String(randomNumber);
  }

  public static (string AccessToken, string RefreshToken, DateTime ExpiresIn) GenerateTokens(User user, IConfiguration configuration)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? ""));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new Claim(ClaimTypes.Email, user.Email),
      new Claim(ClaimTypes.Name, user.DisplayName),
      new Claim(ClaimTypes.Role, user.Role)
    };

    var accessToken = new JwtSecurityToken(
      issuer: configuration["Jwt:Issuer"],
      audience: configuration["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddMinutes(15),
      signingCredentials: creds
    );

    var accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);
    var refreshTokenString = GenerateRandomToken();
    var expiresIn = accessToken.ValidTo;

    return (accessTokenString, refreshTokenString, expiresIn);
  }
}