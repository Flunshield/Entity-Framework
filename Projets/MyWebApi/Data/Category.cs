using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Data;

public class Category
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    // Relation avec les produits
    public List<Product> Products { get; set; } = new();
}