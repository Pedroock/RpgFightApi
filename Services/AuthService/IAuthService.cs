using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.User;
using RpgFight.Models;

namespace RpgFight.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(UserLoginDto request);
        Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto request);
        Task<bool> UserExists(string username);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] PasswordSalt);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] PasswordSalt);
        string CreateToken(User user);
    }
}