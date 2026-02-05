namespace Backend.Models;

public class ProductStock
{
  public int ProductId { get; set; }
  public int WarehouseId { get; set; }
  public int Quantity { get; set; }

  public Product Product { get; set; } = null!;
  public Warehouse Warehouse { get; set; } = null!;
}