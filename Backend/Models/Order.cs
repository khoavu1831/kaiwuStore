namespace Backend.Models;

public class Order
{
  public int Id { get; set; } 
  public int UserId { get; set; }
  public int CartId { get; set; }
  public int AddressId { get; set; }
  public string Status { get; set; } = "pending";
  public decimal TotalPrice { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


  // snapshot address
  public string ReceiverName { get; set; } = null!;
  public string Phone { get; set; } = null!;
  public string AddressLine { get; set; } = null!;
  public string Ward { get; set; } = null!;
  public string District { get; set; } = null!;
  public string City { get; set; } = null!;

  public User User { get; set; } = null!;
  public Cart? Cart { get; set; }
  public Address Address { get; set; } = null!;
  public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
  public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}