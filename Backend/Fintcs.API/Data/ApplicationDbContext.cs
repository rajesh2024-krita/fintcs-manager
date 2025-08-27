
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Models;

namespace Fintcs.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Society> Societies { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User-Society relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Society)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SocietyId)
                .OnDelete(DeleteBehavior.SetNull);

            // Member-Society relationship
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Society)
                .WithMany(s => s.Members)
                .HasForeignKey(m => m.SocietyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Loan-Member relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(l => l.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Loan-Society relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Society)
                .WithMany(s => s.Loans)
                .HasForeignKey(l => l.SocietyId)
                .OnDelete(DeleteBehavior.NoAction);

            // Decimal precision configuration
            modelBuilder.Entity<Society>()
                .Property(s => s.DividendRate)
                .HasPrecision(18, 4);
            
            modelBuilder.Entity<Society>()
                .Property(s => s.ODRate)
                .HasPrecision(18, 4);
            
            modelBuilder.Entity<Society>()
                .Property(s => s.CDRate)
                .HasPrecision(18, 4);
            
            modelBuilder.Entity<Society>()
                .Property(s => s.LoanRate)
                .HasPrecision(18, 4);
            
            modelBuilder.Entity<Society>()
                .Property(s => s.EmergencyLoanRate)
                .HasPrecision(18, 4);
            
            modelBuilder.Entity<Society>()
                .Property(s => s.LASRate)
                .HasPrecision(18, 4);

            // Seed Super Admin
            var superAdminId = 1;
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = superAdminId,
                EDPNo = "ADMIN001",
                Name = "Super Administrator",
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                Role = "SuperAdmin",
                Email = "admin@fintcs.com"
            });
        }
    }
}
