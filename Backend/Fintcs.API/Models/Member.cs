
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models
{
    public class Member
    {
        public int Id { get; set; }
        
        [Required]
        public string MemberNo { get; set; } = string.Empty; // MEM_001, MEM_002, etc.
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string FatherHusbandName { get; set; } = string.Empty;
        public string OfficeAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PhoneOffice { get; set; } = string.Empty;
        public string PhoneResidence { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string ResidenceAddress { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoiningSociety { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime? DateOfJoiningOrg { get; set; }
        public DateTime? DateOfRetirement { get; set; }
        public string Nominee { get; set; } = string.Empty;
        public string NomineeRelation { get; set; } = string.Empty;
        
        public decimal OpeningBalanceShare { get; set; }
        public decimal Value { get; set; }
        public string CrDrCD { get; set; } = string.Empty; // Cr/Dr/CD
        
        // Bank details
        public string BankName { get; set; } = string.Empty;
        public string PayableAt { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        
        // Status
        public bool IsActive { get; set; } = true;
        public DateTime? StatusDate { get; set; }
        
        // Deductions (stored as comma-separated values)
        public string Deductions { get; set; } = string.Empty; // Share, Withdrawal, G Loan Instalment, E Loan Instalment
        
        // File paths for uploads
        public string? PhotoPath { get; set; }
        public string? SignaturePath { get; set; }
        
        public int SocietyId { get; set; }
        public Society Society { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
