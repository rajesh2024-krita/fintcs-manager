
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.DTOs
{
    public class CreateSocietyDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string RegistrationNo { get; set; } = string.Empty;
        
        public decimal DividendRate { get; set; }
        public decimal ODRate { get; set; }
        public decimal CDRate { get; set; }
        public decimal LoanRate { get; set; }
        public decimal EmergencyLoanRate { get; set; }
        public decimal LASRate { get; set; }
        
        public decimal ShareLimit { get; set; }
        public decimal LoanLimit { get; set; }
        public decimal EmergencyLoanLimit { get; set; }
        
        public decimal BounceChargeAmount { get; set; }
        public string BounceChargeType { get; set; } = string.Empty;
    }

    public class SocietyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string RegistrationNo { get; set; } = string.Empty;
        
        public decimal DividendRate { get; set; }
        public decimal ODRate { get; set; }
        public decimal CDRate { get; set; }
        public decimal LoanRate { get; set; }
        public decimal EmergencyLoanRate { get; set; }
        public decimal LASRate { get; set; }
        
        public decimal ShareLimit { get; set; }
        public decimal LoanLimit { get; set; }
        public decimal EmergencyLoanLimit { get; set; }
        
        public decimal BounceChargeAmount { get; set; }
        public string BounceChargeType { get; set; } = string.Empty;
        
        public bool IsPendingApproval { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
