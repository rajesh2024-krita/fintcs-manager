
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Data;
using Fintcs.API.DTOs;
using Fintcs.API.Models;

namespace Fintcs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SocietiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SocietiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,SocietyAdmin,User")]
        public async Task<IActionResult> GetSocieties()
        {
            try
            {
                var societies = await _context.Societies
                    .Select(s => new SocietyDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Address = s.Address,
                        City = s.City,
                        Phone = s.Phone,
                        Fax = s.Fax,
                        Email = s.Email,
                        Website = s.Website,
                        RegistrationNo = s.RegistrationNo,
                        DividendRate = s.DividendRate,
                        ODRate = s.ODRate,
                        CDRate = s.CDRate,
                        LoanRate = s.LoanRate,
                        EmergencyLoanRate = s.EmergencyLoanRate,
                        LASRate = s.LASRate,
                        ShareLimit = s.ShareLimit,
                        LoanLimit = s.LoanLimit,
                        EmergencyLoanLimit = s.EmergencyLoanLimit,
                        BounceChargeAmount = s.BounceChargeAmount,
                        BounceChargeType = s.BounceChargeType,
                        IsPendingApproval = s.IsPendingApproval,
                        CreatedAt = s.CreatedAt,
                        UpdatedAt = s.UpdatedAt
                    })
                    .ToListAsync();

                return Ok(societies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateSociety([FromBody] CreateSocietyDto createSocietyDto)
        {
            try
            {
                var society = new Society
                {
                    Name = createSocietyDto.Name,
                    Address = createSocietyDto.Address,
                    City = createSocietyDto.City,
                    Phone = createSocietyDto.Phone,
                    Fax = createSocietyDto.Fax,
                    Email = createSocietyDto.Email,
                    Website = createSocietyDto.Website,
                    RegistrationNo = createSocietyDto.RegistrationNo,
                    DividendRate = createSocietyDto.DividendRate,
                    ODRate = createSocietyDto.ODRate,
                    CDRate = createSocietyDto.CDRate,
                    LoanRate = createSocietyDto.LoanRate,
                    EmergencyLoanRate = createSocietyDto.EmergencyLoanRate,
                    LASRate = createSocietyDto.LASRate,
                    ShareLimit = createSocietyDto.ShareLimit,
                    LoanLimit = createSocietyDto.LoanLimit,
                    EmergencyLoanLimit = createSocietyDto.EmergencyLoanLimit,
                    BounceChargeAmount = createSocietyDto.BounceChargeAmount,
                    BounceChargeType = createSocietyDto.BounceChargeType
                };

                _context.Societies.Add(society);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetSociety), new { id = society.Id }, society);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSociety(int id)
        {
            try
            {
                var society = await _context.Societies.FindAsync(id);

                if (society == null)
                {
                    return NotFound();
                }

                return Ok(society);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}
