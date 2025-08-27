
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models
{
    public class Loan
    {
        public int Id { get; set; }
        
        [Required]
        public string LoanNo { get; set; } = string.Empty;
        
        [Required]
        public string LoanType { get; set; } = string.Empty; // General, Personal, Housing, Vehicle, Education, Others
        
        public DateTime LoanDate { get; set; } = DateTime.Today;
        
        [Required]
        public string EDPNo { get; set; } = string.Empty;
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public decimal LoanAmount { get; set; }
        public decimal PreviousLoan { get; set; }
        public decimal NetLoan { get; set; } // Auto calculated: LoanAmount - PreviousLoan
        
        public int NoOfInstallments { get; set; }
        public decimal InstallmentAmount { get; set; }
        
        public string Purpose { get; set; } = string.Empty;
        public string AuthorizedBy { get; set; } = string.Empty;
        
        public string PaymentMode { get; set; } = string.Empty; // Cash, Cheque, Opening
        public string Bank { get; set; } = string.Empty;
        
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        
        public int SocietyId { get; set; }
        public Society Society { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
