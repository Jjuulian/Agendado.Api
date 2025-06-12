using AgendadoApi.Data;
using AgendadoApi.DTOs;
using AgendadoApi.Helpers;
using AgendadoApi.Models;
using AgendadoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendadoApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AgendaDbContext _context;

        public UserService(AgendaDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> RegisterUserAsync(UserRegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return (false, "Email ya registrado.");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = PasswordHasher.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Name = dto.Name,
                Surname = dto.Surname,
                Surname2 = dto?.Surname2,
                BirthDate = dto.BirthDate
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, "Usuario registrado correctamente.");
        }

        public async Task<(bool Success, string Message, UserDto? User)> LoginUserAsync(UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return (false, "Credenciales inválidas.", null);

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Surname2 = user.Surname2,
                BirthDate = user.BirthDate,
                Email = user.Email
            };

            return (true, "Login correcto.", userDto);
        }
    }
}
