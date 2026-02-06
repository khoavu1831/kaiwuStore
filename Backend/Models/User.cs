namespace Backend.Models;

public class User
{
  public int Id { get; set; }
  public string Email { get; set; } = null!;
  public string PasswordHash { get; set; } = null!;
  public string DisplayName { get; set; } = null!;
  public string Role { get; set; } = "customer";
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public ICollection<Address> Addresses { get; set; } = new List<Address>();
  public ICollection<Cart> Carts { get; set; } = new List<Cart>();
  public ICollection<Order> Orders { get; set; } = new List<Order>();
  public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}