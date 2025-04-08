using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Dtos;

public class LocationDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "L'adresse est obligatoire")]
    [StringLength(100, ErrorMessage = "L'adresse ne peut pas dépasser 200 caractères")]
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
}