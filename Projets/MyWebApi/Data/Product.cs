using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Data;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    
    public int Stock { get; set; }
    
    // Relation avec la catégorie
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    // Relation avec les articles de commande
    public List<OrderItem> OrderItems { get; set; } = new();
    
    public int Note { get; set; }
    
    public List<PriceHistory> PriceHistory { get; set; } = null!;
}