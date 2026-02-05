namespace Backend.Models;

public class CartItem
{
  public int Id { get; set; }
  public int CartId { get; set; }
  public int ProductId { get; set; }
  public int Quantity { get; set; }
  public DateTime AddedAt { get; set; } = DateTime.UtcNow;

  public Cart Cart { get; set; } = null!;
  public Product Product { get; set; } = null!;
}