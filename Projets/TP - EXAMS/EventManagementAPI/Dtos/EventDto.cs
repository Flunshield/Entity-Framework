using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Name { get; set; } = null!;
        
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string Description { get; set; } = null!;
        
        [Required(ErrorMessage = "La date de début est obligatoire")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "La date de fin est obligatoire")]
        public DateTime EndDate { get; set; }
        
        [Required(ErrorMessage = "L'identifiant du lieu est obligatoire")]
        public int LocationId { get; set; }
        
        public int CategoryId { get; set; } // Ajout de la propriété CategoryId
        
        // Informations pour l'historique des participants
        public DateTime? RegistrationDate { get; set; }
        public string? AttendanceStatus { get; set; }
    }
}