namespace Backend.Models;

public class Warehouse
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? Location { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
  public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}