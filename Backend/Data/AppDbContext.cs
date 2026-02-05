using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<User> Users { get; set; }
  public DbSet<Address> Addresses { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Warehouse> Warehouses { get; set; }
  public DbSet<ProductStock> ProductStocks { get; set; }
  public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
  public DbSet<Cart> Carts { get; set; }
  public DbSet<CartItem> CartItems { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
  public DbSet<Payment> Payments { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // composite key product stock
    modelBuilder.Entity<ProductStock>()
    .HasKey(ps => new { ps.ProductId, ps.WarehouseId });

    // unique cart item
    modelBuilder.Entity<CartItem>()
    .HasIndex(ci => new { ci.CartId, ci.ProductId })
    .IsUnique();

    // unique order item
    modelBuilder.Entity<OrderItem>()
    .HasIndex(oi => new { oi.OrderId, oi.ProductId })
    .IsUnique();

    // category self reference
    modelBuilder.Entity<Category>()
    .HasOne(c => c.Parent)
    .WithMany(c => c.Children)
    .HasForeignKey(c => c.ParentId)
    .OnDelete(DeleteBehavior.Restrict);
  }
}