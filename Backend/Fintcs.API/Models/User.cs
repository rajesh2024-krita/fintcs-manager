
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string EDPNo { get; set; } = string.Empty;
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string AddressOffice { get; set; } = string.Empty;
        public string AddressResidence { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string PhoneOffice { get; set; } = string.Empty;
        public string PhoneResidence { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        [Required]
        public string Role { get; set; } = string.Empty; // SuperAdmin, SocietyAdmin, User, Member
        
        public int? SocietyId { get; set; }
        public Society? Society { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
