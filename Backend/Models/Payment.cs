namespace Backend.Models;

public class Payment
{
  public int Id { get; set; } 
  public int OrderId { get; set; }
  public string PaymentMethod { get; set; } = null!;
  public string Status { get; set; } = "pending";
  public int TransactionId { get; set; }
  public decimal Amount { get; set; }
  public DateTime? PaidAt { get; set; }

  public Order Order { get; set; } = null!;
}