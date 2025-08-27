
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fintcs.API.Data;
using Fintcs.API.DTOs;
using Fintcs.API.Services;

namespace Fintcs.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return null;
            }

            var token = GenerateJwtToken(user.Id, user.Username, user.Role, user.SocietyId);

            return new LoginResponseDto
            {
                Token = token,
                Role = user.Role,
                Name = user.Name,
                SocietyId = user.SocietyId
            };
        }

        public string GenerateJwtToken(int userId, string username, string role, int? societyId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? "defaultsecretkey123456789"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            if (societyId.HasValue)
            {
                claims.Add(new Claim("SocietyId", societyId.Value.ToString()));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"] ?? "fintcs",
                audience: _configuration["JWT:Audience"] ?? "fintcs",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
