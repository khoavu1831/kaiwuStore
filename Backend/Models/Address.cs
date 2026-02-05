namespace Backend.Models;

public class Address
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public string ReceiverName { get; set; } = null!;
  public string Phone { get; set; } = null!;
  public string AddressLine { get; set; } = null!;
  public string Ward { get; set; } = null!;
  public string District { get; set; } = null!;
  public string City { get; set; } = null!;
  public bool IsDefault { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


  public User User { get; set; } = null!;
  public ICollection<Order> Orders { get; set; } = new List<Order>();
}