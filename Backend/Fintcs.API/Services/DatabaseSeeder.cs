
using Fintcs.API.Data;
using Fintcs.API.Models;

namespace Fintcs.API.Services
{
    public class DatabaseSeeder
    {
        private readonly ApplicationDbContext _context;

        public DatabaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Check if data already exists
            if (_context.Societies.Any())
                return;

            // Create sample societies
            var societies = new List<Society>
            {
                new Society
                {
                    Name = "Tech Employees Credit Society",
                    Address = "123 Tech Park, Electronic City",
                    City = "Bangalore",
                    Phone = "+91-80-12345678",
                    Fax = "+91-80-12345679",
                    Email = "info@techcredit.com",
                    Website = "www.techcredit.com",
                    RegistrationNo = "TECS/2020/001",
                    DividendRate = 8.5m,
                    ODRate = 12.0m,
                    CDRate = 6.5m,
                    LoanRate = 10.5m,
                    EmergencyLoanRate = 14.0m,
                    LASRate = 11.0m,
                    ShareLimit = 100000m,
                    LoanLimit = 500000m,
                    EmergencyLoanLimit = 50000m,
                    BounceChargeAmount = 500m,
                    BounceChargeType = "Cash",
                    IsPendingApproval = false
                },
                new Society
                {
                    Name = "Government Employees Cooperative Society",
                    Address = "456 Govt Complex, Vidhana Soudha",
                    City = "Bangalore",
                    Phone = "+91-80-87654321",
                    Email = "contact@govtcoop.org",
                    RegistrationNo = "GECS/2019/002",
                    DividendRate = 7.5m,
                    ODRate = 11.0m,
                    CDRate = 6.0m,
                    LoanRate = 9.5m,
                    EmergencyLoanRate = 13.0m,
                    LASRate = 10.0m,
                    ShareLimit = 75000m,
                    LoanLimit = 300000m,
                    EmergencyLoanLimit = 40000m,
                    BounceChargeAmount = 300m,
                    BounceChargeType = "HDFC Bank",
                    IsPendingApproval = false
                },
                new Society
                {
                    Name = "Metro Rail Employees Society",
                    Address = "789 Metro Bhavan, MG Road",
                    City = "Delhi",
                    Phone = "+91-11-23456789",
                    Email = "support@metrorail.coop",
                    RegistrationNo = "MRES/2021/003",
                    DividendRate = 8.0m,
                    ODRate = 11.5m,
                    CDRate = 6.25m,
                    LoanRate = 10.0m,
                    EmergencyLoanRate = 13.5m,
                    LASRate = 10.5m,
                    ShareLimit = 80000m,
                    LoanLimit = 400000m,
                    EmergencyLoanLimit = 45000m,
                    BounceChargeAmount = 400m,
                    BounceChargeType = "Excess Provision",
                    IsPendingApproval = true
                }
            };

            _context.Societies.AddRange(societies);
            await _context.SaveChangesAsync();

            // Create sample users
            var users = new List<User>
            {
                new User
                {
                    EDPNo = "ADMIN002",
                    Name = "Rajesh Kumar",
                    AddressOffice = "Tech Park, Bangalore",
                    AddressResidence = "HSR Layout, Bangalore",
                    Designation = "Society Administrator",
                    PhoneOffice = "+91-80-12345678",
                    PhoneResidence = "+91-80-98765432",
                    Mobile = "+91-9876543210",
                    Email = "rajesh.kumar@techcredit.com",
                    Username = "rajesh.admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                    Role = "SocietyAdmin",
                    SocietyId = societies[0].Id
                },
                new User
                {
                    EDPNo = "USER001",
                    Name = "Priya Sharma",
                    AddressOffice = "Tech Park, Bangalore",
                    AddressResidence = "Koramangala, Bangalore",
                    Designation = "Software Engineer",
                    PhoneOffice = "+91-80-12345679",
                    Mobile = "+91-9876543211",
                    Email = "priya.sharma@techcredit.com",
                    Username = "priya.user",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                    Role = "User",
                    SocietyId = societies[0].Id
                },
                new User
                {
                    EDPNo = "GOV001",
                    Name = "Amit Singh",
                    AddressOffice = "Vidhana Soudha, Bangalore",
                    AddressResidence = "Jayanagar, Bangalore",
                    Designation = "Assistant Commissioner",
                    PhoneOffice = "+91-80-87654321",
                    Mobile = "+91-9876543212",
                    Email = "amit.singh@govtcoop.org",
                    Username = "amit.admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                    Role = "SocietyAdmin",
                    SocietyId = societies[1].Id
                }
            };

            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();

            // Create sample members
            var members = new List<Member>
            {
                new Member
                {
                    MemberNo = "MEM001",
                    Name = "Suresh Reddy",
                    FatherHusbandName = "Venkata Reddy",
                    OfficeAddress = "Tech Park, Bangalore",
                    City = "Bangalore",
                    PhoneOffice = "+91-80-12345680",
                    PhoneResidence = "+91-80-98765433",
                    Mobile = "+91-9876543213",
                    Designation = "Senior Developer",
                    ResidenceAddress = "Whitefield, Bangalore",
                    DateOfBirth = new DateTime(1985, 6, 15),
                    DateOfJoiningSociety = new DateTime(2020, 1, 15),
                    Email = "suresh.reddy@example.com",
                    DateOfJoiningOrg = new DateTime(2018, 3, 1),
                    Nominee = "Lakshmi Reddy",
                    NomineeRelation = "Wife",
                    OpeningBalanceShare = 25000m,
                    Value = 75000m,
                    CrDrCD = "Cr",
                    BankName = "HDFC Bank",
                    PayableAt = "Koramangala Branch",
                    AccountNo = "12345678901234",
                    IsActive = true,
                    StatusDate = new DateTime(2020, 1, 15),
                    Deductions = "Share,G Loan Instalment",
                    SocietyId = societies[0].Id
                },
                new Member
                {
                    MemberNo = "MEM002",
                    Name = "Deepika Rao",
                    FatherHusbandName = "Mohan Rao",
                    OfficeAddress = "Tech Park, Bangalore",
                    City = "Bangalore",
                    PhoneOffice = "+91-80-12345681",
                    Mobile = "+91-9876543214",
                    Designation = "Project Manager",
                    ResidenceAddress = "Indiranagar, Bangalore",
                    DateOfBirth = new DateTime(1988, 9, 22),
                    DateOfJoiningSociety = new DateTime(2020, 3, 10),
                    Email = "deepika.rao@example.com",
                    DateOfJoiningOrg = new DateTime(2019, 1, 15),
                    Nominee = "Rakesh Rao",
                    NomineeRelation = "Brother",
                    OpeningBalanceShare = 30000m,
                    Value = 65000m,
                    CrDrCD = "Cr",
                    BankName = "SBI",
                    PayableAt = "Indiranagar Branch",
                    AccountNo = "98765432109876",
                    IsActive = true,
                    StatusDate = new DateTime(2020, 3, 10),
                    Deductions = "Share,Withdrawal",
                    SocietyId = societies[0].Id
                },
                new Member
                {
                    MemberNo = "GOV001",
                    Name = "Vikram Joshi",
                    FatherHusbandName = "Raghunath Joshi",
                    OfficeAddress = "Vidhana Soudha, Bangalore",
                    City = "Bangalore",
                    PhoneOffice = "+91-80-87654322",
                    Mobile = "+91-9876543215",
                    Designation = "Deputy Secretary",
                    ResidenceAddress = "Rajajinagar, Bangalore",
                    DateOfBirth = new DateTime(1982, 12, 5),
                    DateOfJoiningSociety = new DateTime(2019, 6, 1),
                    Email = "vikram.joshi@example.com",
                    DateOfJoiningOrg = new DateTime(2010, 7, 1),
                    Nominee = "Sunita Joshi",
                    NomineeRelation = "Wife",
                    OpeningBalanceShare = 40000m,
                    Value = 85000m,
                    CrDrCD = "Cr",
                    BankName = "Canara Bank",
                    PayableAt = "Rajajinagar Branch",
                    AccountNo = "56789012345678",
                    IsActive = true,
                    StatusDate = new DateTime(2019, 6, 1),
                    Deductions = "Share,G Loan Instalment,E Loan Instalment",
                    SocietyId = societies[1].Id
                },
                new Member
                {
                    MemberNo = "MET001",
                    Name = "Anitha Nair",
                    FatherHusbandName = "Krishna Nair",
                    OfficeAddress = "Metro Bhavan, Delhi",
                    City = "Delhi",
                    PhoneOffice = "+91-11-23456790",
                    Mobile = "+91-9876543216",
                    Designation = "Station Manager",
                    ResidenceAddress = "Dwarka, Delhi",
                    DateOfBirth = new DateTime(1990, 4, 18),
                    DateOfJoiningSociety = new DateTime(2021, 8, 1),
                    Email = "anitha.nair@example.com",
                    DateOfJoiningOrg = new DateTime(2020, 2, 1),
                    Nominee = "Ravi Nair",
                    NomineeRelation = "Husband",
                    OpeningBalanceShare = 20000m,
                    Value = 45000m,
                    CrDrCD = "Cr",
                    BankName = "ICICI Bank",
                    PayableAt = "Dwarka Branch",
                    AccountNo = "13579024681357",
                    IsActive = true,
                    StatusDate = new DateTime(2021, 8, 1),
                    Deductions = "Share",
                    SocietyId = societies[2].Id
                }
            };

            _context.Members.AddRange(members);
            await _context.SaveChangesAsync();

            // Create sample loans
            var loans = new List<Loan>
            {
                new Loan
                {
                    LoanNo = "GL001",
                    LoanType = "General",
                    LoanDate = new DateTime(2023, 1, 15),
                    EDPNo = "MEM001",
                    Name = "Suresh Reddy",
                    LoanAmount = 200000m,
                    PreviousLoan = 0m,
                    NetLoan = 200000m,
                    NoOfInstallments = 24,
                    InstallmentAmount = 9166.67m,
                    Purpose = "Home renovation",
                    AuthorizedBy = "Rajesh Kumar",
                    PaymentMode = "Cheque",
                    Bank = "HDFC Bank",
                    MemberId = members[0].Id,
                    SocietyId = societies[0].Id
                },
                new Loan
                {
                    LoanNo = "PL001",
                    LoanType = "Personal",
                    LoanDate = new DateTime(2023, 3, 20),
                    EDPNo = "MEM002",
                    Name = "Deepika Rao",
                    LoanAmount = 100000m,
                    PreviousLoan = 0m,
                    NetLoan = 100000m,
                    NoOfInstallments = 12,
                    InstallmentAmount = 8916.67m,
                    Purpose = "Medical expenses",
                    AuthorizedBy = "Rajesh Kumar",
                    PaymentMode = "Cash",
                    Bank = "",
                    MemberId = members[1].Id,
                    SocietyId = societies[0].Id
                },
                new Loan
                {
                    LoanNo = "EL001",
                    LoanType = "Emergency",
                    LoanDate = new DateTime(2023, 6, 10),
                    EDPNo = "GOV001",
                    Name = "Vikram Joshi",
                    LoanAmount = 50000m,
                    PreviousLoan = 0m,
                    NetLoan = 50000m,
                    NoOfInstallments = 6,
                    InstallmentAmount = 8916.67m,
                    Purpose = "Emergency family expenses",
                    AuthorizedBy = "Amit Singh",
                    PaymentMode = "Cheque",
                    Bank = "Canara Bank",
                    MemberId = members[2].Id,
                    SocietyId = societies[1].Id
                },
                new Loan
                {
                    LoanNo = "HL001",
                    LoanType = "Housing",
                    LoanDate = new DateTime(2023, 8, 5),
                    EDPNo = "MET001",
                    Name = "Anitha Nair",
                    LoanAmount = 300000m,
                    PreviousLoan = 0m,
                    NetLoan = 300000m,
                    NoOfInstallments = 36,
                    InstallmentAmount = 9166.67m,
                    Purpose = "House purchase",
                    AuthorizedBy = "Metro Admin",
                    PaymentMode = "Cheque",
                    Bank = "ICICI Bank",
                    MemberId = members[3].Id,
                    SocietyId = societies[2].Id
                }
            };

            _context.Loans.AddRange(loans);
            await _context.SaveChangesAsync();
        }
    }
}
