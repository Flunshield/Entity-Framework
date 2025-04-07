using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Data;

public class PriceHistory
{
    public int Id { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    // Relation avec le produit (many-to-one)
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}