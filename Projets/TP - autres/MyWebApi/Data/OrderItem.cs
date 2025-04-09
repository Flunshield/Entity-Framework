using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Data;

public class OrderItem
{
    public int Id { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }
    
    // Relation avec la commande
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    
    // Relation avec le produit
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}