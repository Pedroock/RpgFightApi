using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Data;
using RpgFight.Models;
using RpgFight.Services.DMService;
using RpgFight.Services.EffectService;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RpgFight.Services.HttpContextService;
using AutoMapper;

namespace RpgFight.Services.ArenaService
{
    public class ArenaService : IArenaService
    {
        private readonly DataContext _context;
        private readonly IEffectService _fxService;
        private readonly IDMService _dmService;
        private readonly IHttpContextService _httpContextService;
        private readonly IMapper _mapper;
        public ArenaService(DataContext context, IDMService dmService, IEffectService fxService, IHttpContextService httpContextService, IMapper mapper)
        {
            _context = context;
            _httpContextService = httpContextService;
            _dmService = dmService;
            _fxService = fxService;
            _mapper = mapper;
        }
        // Needed Methods 
        private async Task<User> GetCurrentUser()
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == _httpContextService.GetCurrentUserId());
            return user!;
        }
        private async Task<bool> HasBattleModels()
        {
            var battleChar = await _context.BattleCharacters
                .FirstOrDefaultAsync(be => be.UserId == _httpContextService.GetCurrentUserId());
            var battleEnemy = await _context.BattleEnemies
                .FirstOrDefaultAsync(be => be.UserId == _httpContextService.GetCurrentUserId());
            if(battleEnemy is null & battleChar is null)
            {
                return false;
            }
            return true;
        }
        // SetUpBattle
        private BattleCharacter HardMapBattleCharacter(Character c)
        {
            var battleChar = new BattleCharacter{
            Name = c.Name,
            HitPoint = c.HitPoint,
            Strength = c.Strength,
            Intelligence = c.Intelligence,
            Defense = c.Defense,
            Class = c.Class,
            Weapon = c.Weapon,
            Armor = c.Armor,
            Skill = c.Skill,
            User = GetCurrentUser().Result,
            UserId = _httpContextService.GetCurrentUserId(),
            };
            return battleChar;
        }
        private void HardEditBattleCharacter(Character c)
        {
            var battleChar = _context.BattleCharacters
                .FirstOrDefault(be => be.UserId == _httpContextService.GetCurrentUserId());
            battleChar!.Name = c.Name;
            battleChar.HitPoint = c.HitPoint;
            battleChar.Strength = c.Strength;
            battleChar.Intelligence = c.Intelligence;
            battleChar.Defense = c.Defense;
            battleChar.Class = c.Class;
            battleChar.Weapon = c.Weapon;
            battleChar.Armor = c.Armor;
            battleChar.Skill = c.Skill;
        }
        private BattleEnemy HardMapBattleEnemy(Enemy e)
        {
            var battleEnemy = new BattleEnemy{
                Name = e.Name,
                HitPoint = e.HitPoint,
                Strength = e.Strength,
                Intelligence = e.Intelligence,
                Defense = e.Defense,
                Class = e.Class,
                Weapon = e.Weapon,
                Armor = e.Armor,
                Skill = e.Skill,
                User = GetCurrentUser().Result,
                UserId = _httpContextService.GetCurrentUserId(),
            };
            return battleEnemy;
        }
        private void HardEditBattleEnemy(Enemy e)
        {
            var battleEnemy = _context.BattleEnemies
                .FirstOrDefault(be => be.UserId == _httpContextService.GetCurrentUserId());
            battleEnemy!.Name = e.Name;
            battleEnemy.HitPoint = e.HitPoint;
            battleEnemy.Strength = e.Strength;
            battleEnemy.Intelligence = e.Intelligence;
            battleEnemy.Defense = e.Defense;
            battleEnemy.Class = e.Class;
            battleEnemy.Weapon = e.Weapon;
            battleEnemy.Armor = e.Armor;
            battleEnemy.Skill = e.Skill;
        }
        public async Task<ServiceResponse<bool>> SetUpBattle()
        {
            var response = new ServiceResponse<bool>();
            var c = await _httpContextService.GetCurrentCharacter();
            var enemy = await _httpContextService.GetCurrentEnemy();
            var user = GetCurrentUser().Result;
            if(c.Data is null)
            {
                response.Success = false;
                response.Message = c.Message;
                return response;
            }
            if(enemy.Data is null)
            {
                response.Success = false;
                response.Message = enemy.Message;
                return response;
            }
            if(HasBattleModels().Result is false)
            {
                var battleChar = HardMapBattleCharacter(c.Data);
                var battleEnemy = HardMapBattleEnemy(enemy.Data);
                _context.BattleCharacters.Add(battleChar);
                _context.BattleEnemies.Add(battleEnemy);
                await _context.SaveChangesAsync();
                response.Message = "The battle models have been created";
            }
            else
            {
                HardEditBattleCharacter(c.Data);
                HardEditBattleEnemy(enemy.Data);
                await _context.SaveChangesAsync();
                response.Message = "The battle models have been updated";
            }
            response.Data = true;
            return response;
        }
        // Apply passives
        private void ApplyClassPassive()
        {
            var battleChar =  _context.BattleCharacters
                .FirstOrDefault(bc => bc.UserId == _httpContextService.GetCurrentUserId());
            if(battleChar!.Class is null)
            {
                return;
            }
            var classIdChar = battleChar.Class!.Id;
            switch(classIdChar)
            {
                case 1:
                    battleChar.Intelligence += 5;
                    battleChar.Strength += 5;
                    battleChar.HitPoint += 15;
                    battleChar.Defense += 5;
                    return;
                case 2:
                    battleChar.Strength += 10;
                    battleChar.HitPoint += 10;
                    battleChar.Defense += 10;
                    return;
                case 3:
                    battleChar.Intelligence -= 5;
                    battleChar.Strength += 30;
                    battleChar.HitPoint += 10;
                    battleChar.Defense -= 5;
                    return;
                case 4:
                    battleChar.Intelligence += 30;
                    battleChar.Strength -= 5;
                    battleChar.HitPoint += 10;
                    battleChar.Defense -= 5;
                    return;
                case 5:
                    battleChar.Intelligence += 20;
                    battleChar.Strength += 10;
                    battleChar.HitPoint -= 10;
                    battleChar.Defense += 10;
                    return;
            }
            var battleEnemy = _context.BattleEnemies
                .FirstOrDefault(bc => bc.UserId == _httpContextService.GetCurrentUserId());
            if(battleEnemy!.Class is null)
            {
                return;
            }
            var classIdEnemy = battleEnemy.Class!.Id;
            switch(classIdEnemy)
            {
                case 1:
                    battleEnemy.Intelligence += 5;
                    battleEnemy.Strength += 5;
                    battleEnemy.HitPoint += 15;
                    battleEnemy.Defense += 5;
                    return;
                case 2:
                    battleEnemy.Strength += 10;
                    battleEnemy.HitPoint += 10;
                    battleEnemy.Defense += 10;
                    return;
                case 3:
                    battleEnemy.Intelligence -= 5;
                    battleEnemy.Strength += 30;
                    battleEnemy.HitPoint += 10;
                    battleEnemy.Defense -= 5;
                    return;
                case 4:
                    battleEnemy.Intelligence += 30;
                    battleEnemy.Strength -= 5;
                    battleEnemy.HitPoint += 10;
                    battleEnemy.Defense -= 5;
                    return;
                case 5:
                    battleEnemy.Intelligence += 20;
                    battleEnemy.Strength += 10;
                    battleEnemy.HitPoint -= 10;
                    battleEnemy.Defense += 10;
                    return;
            }
        }
        public async Task<ServiceResponse<bool>> ApplyPassives()
        {
            var response = new ServiceResponse<bool>();
            ApplyClassPassive();
            await _context.SaveChangesAsync();
            response.Message = "The passive changes have been applied";
            return response;
        }
        // Fight
        public async Task<FightResponse> Fight()
        {
            throw new NotImplementedException();
        }
        public async Task<RoundResponse> FightOneRound()
        {
            throw new NotImplementedException();
        }

    }
}