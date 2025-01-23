using AIDreamDecoder.Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(UserRegistrationDto registrationDto);
        Task<(UserDto User, string Token)> LoginAsync(UserLoginDto loginDto);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(Guid id, UserDto userDto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<bool> UserExists(Guid userId);
    }
}
