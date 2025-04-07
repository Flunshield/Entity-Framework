using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Data;

public class Order
{
    public int Id { get; set; }
    
    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    
    public DateTime? DeliveryDate { get; set; }
    
    [Required]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    
    // Relation avec le client
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    // Relation avec les articles de commande
    public List<OrderItem> OrderItems { get; set; } = new();
    
    [MaxLength(500)]
    public string? Notes { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}