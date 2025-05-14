using AgendadoApi.DTOs;

namespace AgendadoApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<(bool Success, string Message)> RegisterUserAsync(UserRegisterDto dto);
        Task<(bool Success, string Message)> LoginUserAsync(UserLoginDto dto);
    }
}
