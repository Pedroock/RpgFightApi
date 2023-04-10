using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Data;
using AutoMapper;
using RpgFight.Models;
using RpgFight.Dtos.Enemy;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using RpgFight.Services.WardrobeService;
using RpgFight.Services.DMService;
using RpgFight.Services.HttpContextService;

namespace RpgFight.Services.GuildService
{
    public class GuildService : IGuildService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IWardrobeService _wardrobe;
        private readonly IDMService _dmService;
        private readonly IHttpContextService _httpContextService;
        public GuildService(IMapper mapper, DataContext context, IWardrobeService wardrobe, IDMService dmService, IHttpContextService httpContextService)
        {
            _context = context;
            _mapper = mapper;
            _wardrobe = wardrobe;
            _dmService = dmService;
            _httpContextService = httpContextService;
        }
        // Needed Methods
        private async Task<Enemy> GetEnemyById(int id)
        {
            var enemy = await _context.Enemies
                .Include(c => c.Class).Include(c => c.Weapon).Include(c => c.Skill).Include(c => c.Armor)
                .FirstOrDefaultAsync(e => e.Id == id);
            return enemy!;
        }
        private async Task<bool> EnemyExists(int id)
        {
            if(await _context.Enemies.FirstOrDefaultAsync(e => e.Id == id) is not null)
            {
                return true;
            }
            return false;
        }
        // Enemy Methods
        public async Task<ServiceResponse<List<GetEnemyDto>>> LookAtAllEnemies()
        {
            var response = new ServiceResponse<List<GetEnemyDto>>();
            var enemies = await _context.Enemies // didnt include gear so the list could be less crowded
                .ToListAsync();
            var enemiesDto = new List<GetEnemyDto>();
            foreach(var e in enemies)
            {
                enemiesDto.Add(_mapper.Map<GetEnemyDto>(e));
            }
            response.Data = enemiesDto;
            response.Message = "Theese are all available enemies";
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> SelectEnemy(int id)
        {
            var response = new ServiceResponse<GetEnemyDto>();
            if(await EnemyExists(id))
            {
                var c = _httpContextService.GetCurrentCharacter();
                if(c.Result.Data is null)
                {
                    response.Success = false;
                    response.Message = c.Result.Message;
                    return response;
                }
                c.Result.Data.EnemyId = id;
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetEnemyDto>(await GetEnemyById(id));
                response.Message = "You have selected your enemy";
                return response;
            }
            response.Success = false;
            response.Message = "There is no enemy with this Id";
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> CreateEnemy(AddEnemyDto request)
        {
            var response = new ServiceResponse<GetEnemyDto>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _httpContextService.GetCurrentUserId());
            if(request.Strength + request.Defense + request.Intelligence != 30 | request.Defense < 5 | request.Strength < 5 | request.Intelligence < 5)
            {
                response.Success = false;
                response.Message = "The sum of the enemy stats can't be greater than 30 and all stats must be greater than 5";
                return response;
            }
            var enemy = _mapper.Map<Enemy>(request);
            _context.Enemies.Add(enemy);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetEnemyDto>(enemy);
            response.Message = $"You have created {request.Name}";
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> LookAtEnemy()
        {
            var response = new ServiceResponse<GetEnemyDto>();
            var c = await _httpContextService.GetCurrentCharacter();
            if(c.Data is null)
            {
                response.Success = false;
                response.Message = c.Message;
                return response;
            }
            var enemyId = c.Data!.EnemyId;
            if(await EnemyExists(enemyId))
            {
                var enemy = GetEnemyById(enemyId).Result;
                var enemyDto = _mapper.Map<GetEnemyDto>(enemy);
                if(enemy.Weapon is not null)
                    enemyDto.Weapon = _dmService.GetWeaponById(enemy.Weapon!.Id).Result.Data;
                if(enemy.Armor is not null)
                    enemyDto.Armor = _dmService.GetArmorById(enemy.Armor!.Id).Result.Data;
                if(enemy.Skill is not null)
                    enemyDto.Skill = _dmService.GetSkillById(enemy.Skill!.Id).Result.Data;
                response.Data = enemyDto;
                response.Message = "This is your selected enemy";
                return response;
            }
            response.Success = false;
            response.Message = "You have not selected any enemy yet";
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> EquipClass(int classId)
        {
            var response = new ServiceResponse<GetEnemyDto>();
            var enemy = await _httpContextService.GetCurrentEnemy();
            if(enemy is null)
            {
                response.Success = false;
                response.Message = enemy!.Message;
                return response;
            } 
            var cls = _dmService.GetClassModelById(classId);
            if (cls.Result.Success == false)
            {
                response.Success = false;
                response.Message = cls.Result.Message;
                return response;
            }
            enemy.Data!.Class = cls.Result.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your enemy's new class is {cls.Result.Data!.Name}";
            response.Data = LookAtEnemy().Result.Data;
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> EquipWeapon(int weaponId)
        {
            var response = new ServiceResponse<GetEnemyDto>();
            var enemy = await _httpContextService.GetCurrentEnemy();
            if(enemy is null)
            {
                response.Success = false;
                response.Message = enemy!.Message;
                return response;
            } 
            var weapon = _dmService.GetWeaponModelById(weaponId);
            if (weapon.Result.Success == false)
            {
                response.Success = false;
                response.Message = weapon.Result.Message;
                return response;
            }
            enemy.Data!.Weapon = weapon.Result.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your enemy's new weapon is {weapon.Result.Data!.Name}";
            response.Data = LookAtEnemy().Result.Data;
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> EquipSkill(int skillId)
        {
            var response = new ServiceResponse<GetEnemyDto>();
            var enemy = await _httpContextService.GetCurrentEnemy();
            if(enemy is null)
            {
                response.Success = false;
                response.Message = enemy!.Message;
                return response;
            } 
            var skill = _dmService.GetSkillModelById(skillId);
            if (skill.Result.Success == false)
            {
                response.Success = false;
                response.Message = skill.Result.Message;
                return response;
            }
            enemy.Data!.Skill = skill.Result.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your enemy's new skill is {skill.Result.Data!.Name}";
            response.Data = LookAtEnemy().Result.Data;
            return response;
        }
        public async Task<ServiceResponse<GetEnemyDto>> EquipArmor(int armorId)
        {
            var response = new ServiceResponse<GetEnemyDto>();
            var enemy = await _httpContextService.GetCurrentEnemy();
            if(enemy is null)
            {
                response.Success = false;
                response.Message = enemy!.Message;
                return response;
            } 
            var armor = _dmService.GetArmorModelById(armorId);
            if (armor.Result.Success == false)
            {
                response.Success = false;
                response.Message = armor.Result.Message;
                return response;
            }
            enemy.Data!.Armor = armor.Result.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your enemy's new armor is {armor.Result.Data!.Name}";
            response.Data = LookAtEnemy().Result.Data;
            return response;
        }
    }
}