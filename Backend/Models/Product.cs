namespace Backend.Models;

public class Product
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
  public decimal Price { get; set; }
  public string Status { get; set; } = "active";
  public int CategoryId { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public Category Category { get; set; } = null!;
  public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
  public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
  public ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
  public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}