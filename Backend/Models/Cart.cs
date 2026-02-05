namespace Backend.Models;

public class Cart
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  public string Status { get; set; } = "active";

  public User User { get; set; } = null!;
  public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
  public ICollection<Order> Orders { get; set; } = new List<Order>();
}