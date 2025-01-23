using AIDreamDecoder.Application.Dtos.UserDtos;
using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AIDreamDecoderDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _tokenGenerator;

        public UserService(
            AIDreamDecoderDbContext context,
            IPasswordHasher<User> passwordHasher,
            IJwtService tokenGenerator)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserDto> RegisterAsync(UserRegistrationDto registrationDto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == registrationDto.Email);

            if (existingUser != null)
                throw new InvalidOperationException("User with this email already exists");

            var user = new User
            {
                Email = registrationDto.Email,
                PasswordHash = _passwordHasher.HashPassword(null, registrationDto.Password),
                Name = registrationDto.Name
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return MapToDto(user);
        }

        public async Task<(UserDto User, string Token)> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || _passwordHasher.VerifyHashedPassword(null, user.PasswordHash, loginDto.Password) == PasswordVerificationResult.Failed)
                throw new InvalidOperationException("Invalid credentials");

            var userDto = MapToDto(user);
            string token = _tokenGenerator.GenerateToken(user.Email);
            return (userDto, token);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            return user != null ? MapToDto(user) : throw new KeyNotFoundException("User not found");
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null ? MapToDto(user) : throw new KeyNotFoundException("User not found");
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(MapToDto).ToList();
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Name = userDto.Name;
            user.Email = userDto.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private static UserDto MapToDto(User user) => new()
        {
            UserId = user.UserId,
            Email = user.Email,
            Name = user.Name
        };

        public async Task<bool> UserExists(Guid userId)
        {
            return await _context.Users.AnyAsync(u => u.UserId == userId);
        }
    }
}
