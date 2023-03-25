using Microsoft.AspNetCore.Mvc;
using TalabaMVC.Models;

namespace TalabaMVC.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto dto);

        Task<string> CreateToken();

        Task<UserDto> GetUserWithToken(string username, bool hasToken = true);

        Task<Response> ValidateToken(string token);

        Task<string> AddUser(RegisterUserDto dto, string role);

        Task<UserDto> GetUser(string token);
    }
}
