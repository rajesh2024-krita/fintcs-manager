
using Fintcs.API.DTOs;

namespace Fintcs.API.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
        string GenerateJwtToken(int userId, string username, string role, int? societyId);
    }
}
