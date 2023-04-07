using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RpgFight.Models;

namespace RpgFight.Services.HttpContextService
{
    public class HttpContextService : IHttpContextService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public HttpContextService(DataContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public int GetCurrentUserId() => int.Parse(
            _httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
        public async Task<ServiceResponse<Character>> GetCurrentCharacter() 
        {
            var response = new ServiceResponse<Character>();
            var c = await _context.Characters
                .Include(c => c.Class).Include(c => c.Armor).Include(c => c.Skill).Include(c => c.Weapon)
                .FirstOrDefaultAsync(c => c.UserId == GetCurrentUserId());
            if (c is null)
            {
                response.Success = false;
                response.Message = "You have no character, create one first";
                return response;
            }
            response.Message = "This is your current character";
            response.Data = c;
            return response;
        }
        public async Task<ServiceResponse<Enemy>> GetCurrentEnemy()
        {
            var response = new ServiceResponse<Enemy>();
            var c = GetCurrentCharacter();
            if(c.Result.Data is null)
            {
                response.Success = false;
                response.Message = c.Result.Message;
                return response;
            }
            var enemy = await _context.Enemies
                .Include(c => c.Class).Include(c => c.Weapon).Include(c => c.Skill).Include(c => c.Armor)
                .FirstOrDefaultAsync(e => e.Id == c.Result.Data.EnemyId);
            if(enemy is null)
            {
                response.Success = false;
                response.Message = "You have no selected enemy";
                return response;
            }
            response.Message = "This is the current enemy model";
            response.Data = enemy;
            return response;
        }
    }
}