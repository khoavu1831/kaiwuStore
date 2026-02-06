namespace Backend.Models;

public class RefreshToken
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public string Token { get; set; } = null!;
  public DateTime ExpiresAt { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public bool IsRevoked { get; set; } = false;

  public User User { get; set; } = null!;
}