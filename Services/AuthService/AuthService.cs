using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Data;
using RpgFight.Dtos.User;
using RpgFight.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace RpgFight.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AuthService(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        // Login
        public async Task<ServiceResponse<string>> Login(UserLoginDto request)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }
            if(VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Data = CreateToken(user);
                response.Message = "You have successfully logged in";
                return response;
            }
            response.Success = false;
            response.Message = "Wrong passoword";
            return response;
        }
        // Register
        public async Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto request)
        {
            var response = new ServiceResponse<GetUserDto>();
            if (await UserExists(request.Username))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] PasswordSalt);
            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = PasswordSalt
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Message = $"The user  {user.Username}  has been created";
            response.Data = _mapper.Map<GetUserDto>(user);
            return response;
        }
        // Check user
        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(u => u.Username == username))
            {
                return true;
            }
            return false;
        }
        // Create hash
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        // Verify password
        public bool VerifyPassword(string testPassword, byte[] passwordHash, byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var testHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(testPassword));
                return testHash.SequenceEqual(passwordHash);
            }
        }
        // Create Token
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            var appSettingsPassword = _configuration.GetSection("AppSettings:Token").Value;
            if (appSettingsPassword is null)
            {
                throw new Exception("AppSettingsPassword wasn't found");
            }
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(appSettingsPassword));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}