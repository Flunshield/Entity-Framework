using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Data;

public class Customer
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;
    
    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
    // Relation avec les commandes
    public List<Order> Orders { get; set; } = new();
    
    [MaxLength(500)]
    public string Adresse { get; set; } = string.Empty;
    
}