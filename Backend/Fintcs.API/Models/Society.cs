
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models
{
    public class Society
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string RegistrationNo { get; set; } = string.Empty;
        
        // Interest rates
        public decimal DividendRate { get; set; }
        public decimal ODRate { get; set; }
        public decimal CDRate { get; set; }
        public decimal LoanRate { get; set; }
        public decimal EmergencyLoanRate { get; set; }
        public decimal LASRate { get; set; }
        
        // Limits
        public decimal ShareLimit { get; set; }
        public decimal LoanLimit { get; set; }
        public decimal EmergencyLoanLimit { get; set; }
        
        // Bounce charge
        public decimal BounceChargeAmount { get; set; }
        public string BounceChargeType { get; set; } = string.Empty; // Excess Provision, Cash, HDFC Bank, Inverter
        
        public bool IsPendingApproval { get; set; } = false;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
