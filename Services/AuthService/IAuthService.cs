using PLACTECUGHH.DTOs.Auth;

namespace PLACTECUGHH.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> EmailExistsAsync(string email);
        Task RegisterAsync(RegisterDTO dto);
    }
}
