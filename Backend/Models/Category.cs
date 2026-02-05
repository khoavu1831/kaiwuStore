namespace Backend.Models;

public class Category
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
  public int ParentId { get; set; }
  public bool IsMain { get; set; }

  public Category? Parent { get; set; }
  public ICollection<Category> Children { get; set; } = new List<Category>();
  public ICollection<Product> Products { get; set; } = new List<Product>();
}