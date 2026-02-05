namespace Backend.Models;

public class InventoryTransaction
{
  public int Id { get; set; }
  public int ProductId { get; set; }
  public int WarehouseId { get; set; }
  public string Type { get; set; } = null!; // in | out | adjust
  public int Quantity { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public string? Note { get; set; }


  public Product Product { get; set; } = null!;
  public Warehouse Warehouse { get; set; } = null!;
}