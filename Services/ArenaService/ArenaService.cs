
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
using RpgFight.Dtos.Effect;
using RpgFight.Models.Joins;

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
            var battleModel = await _context.BattleModels
                .FirstOrDefaultAsync(be => be.UserId == _httpContextService.GetCurrentUserId());
            if(battleModel is null )
            {
                return false;
            }
            return true;
        }
        // SetUpBattle
        private async Task<BattleModel> HardMapBattleCharacter(Character c)
        {
            var battleChar = new BattleModel{
            Name = c.Name,
            HitPoint = c.HitPoint,
            Strength = c.Strength,
            Intelligence = c.Intelligence,
            Defense = c.Defense,
            Class = c.Class,
            Weapon = c.Weapon,
            Armor = c.Armor,
            Skill = c.Skill,
            IsChar = true,
            User = await GetCurrentUser(),
            UserId = _httpContextService.GetCurrentUserId(),
            };
            return battleChar;
        }
        private void HardEditBattleCharacter(Character c)
        {
            var battleChar = _context.BattleModels.FirstOrDefault
                (bc => bc.UserId == _httpContextService.GetCurrentUserId() & bc.IsChar == true);
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
        private async Task<BattleModel> HardMapBattleEnemy(Enemy e)
        {
            var battleEnemy = new BattleModel{
                Name = e.Name,
                HitPoint = e.HitPoint,
                Strength = e.Strength,
                Intelligence = e.Intelligence,
                Defense = e.Defense,
                Class = e.Class,
                Weapon = e.Weapon,
                Armor = e.Armor,
                Skill = e.Skill,
                IsChar = false,
                User = await GetCurrentUser(),
                UserId = _httpContextService.GetCurrentUserId(),
            };
            return battleEnemy;
        }
        private void HardEditBattleEnemy(Enemy e)
        {
            var battleEnemy = _context.BattleModels.FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == false);
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
        private void CleanEffects()
        {
            var battleEnemy = _context.BattleModels.FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == false);
            var battleChar = _context.BattleModels.FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == true);
            var bCharFxs = _context.BattleModelEffects.Where(bme => bme.BattleModelId == battleChar!.Id);
            var bEnemyFxs = _context.BattleModelEffects.Where(bme => bme.BattleModelId == battleEnemy!.Id);
            _context.BattleModelEffects.RemoveRange(bCharFxs);
            _context.BattleModelEffects.RemoveRange(bEnemyFxs);
            _context.SaveChanges();
        }
        public async Task<VoidServiceResponse> SetUpBattle()
        {
            var response = new VoidServiceResponse();
            var c = await _httpContextService.GetCurrentCharacter();
            var enemy = await _httpContextService.GetCurrentEnemy();
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
            if(await HasBattleModels() is false)
            {
                var battleChar = await HardMapBattleCharacter(c.Data);
                var battleEnemy = await HardMapBattleEnemy(enemy.Data);
                _context.BattleModels.Add(battleEnemy);
                _context.BattleModels.Add(battleChar);
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
            CleanEffects();
            return response;
        }
        // Apply passives
        private VoidServiceResponse ApplyClassPassive(BattleModel battleModel)
        {
            var response = new VoidServiceResponse();
            if(battleModel!.Class is null)
            {
                response.Message = "There is no class for the character";
                return response;
            }
            var classIdChar = battleModel.Class!.Id;
            switch(classIdChar)
            {
                case 1:
                    battleModel.Intelligence += 5;
                    battleModel.Strength += 5;
                    battleModel.HitPoint += 15;
                    battleModel.Defense += 5;
                    response.Message = "Knight";
                    return response;
                case 2:
                    battleModel.Strength += 10;
                    battleModel.HitPoint += 10;
                    battleModel.Defense += 10;
                    response.Message = "Crusader";
                    return response;
                case 3:
                    battleModel.Intelligence -= 5;
                    battleModel.Strength += 30;
                    battleModel.HitPoint += 10;
                    battleModel.Defense -= 5;
                    response.Message = "Berserker";
                    return response;
                case 4:
                    battleModel.Intelligence += 30;
                    battleModel.Strength -= 5;
                    battleModel.HitPoint += 10;
                    battleModel.Defense -= 5;
                    response.Message = "Mage";
                    return response;
                case 5:
                    battleModel.Intelligence += 20;
                    battleModel.Strength += 10;
                    battleModel.HitPoint -= 10;
                    battleModel.Defense += 10;
                    response.Message = "Witch";
                    return response;
            }
            response.Success = false;
            response.Message = "ClassId error";
            return response;
        }
        private VoidServiceResponse ApplyWeaponPassive(BattleModel battleModel)
        {
            var response = new VoidServiceResponse();
            if(battleModel.Weapon is null)
            {
                response.Message = "There is no weapon";
                return response;
            }
            var fxs = _fxService.GetWeaponFxById(battleModel.Weapon!.Id).Result;
            foreach(GetEffectDto fx in fxs)
            {
                switch(fx.Id)
                {
                    case 7:
                        battleModel.Strength += 5;
                        break;
                    case 8:
                        battleModel.Strength -= 5;
                        break;
                    case 9:
                        battleModel.Intelligence += 5;
                        break;
                    case 10:
                        battleModel.Intelligence -= 5;
                        break;
                    case 11:
                        battleModel.Defense += 5;
                        break;
                    case 12:
                        battleModel.Defense -= 5;
                        break;
                }
            }
            return response;
        }
        private VoidServiceResponse ApplyArmorPassive(BattleModel battleModel)
        {
            var response = new VoidServiceResponse();
            if(battleModel.Armor is null)
            {
                response.Message = "There is no armor";
                return response;
            }
            var fxs = _fxService.GetArmorFxById(battleModel.Armor!.Id).Result;
            foreach(GetEffectDto fx in fxs)
            {
                switch(fx.Id)
                {
                    case 7:
                        battleModel.Strength += 5;
                        break;
                    case 8:
                        battleModel.Strength -= 5;
                        break;
                    case 9:
                        battleModel.Intelligence += 5;
                        break;
                    case 10:
                        battleModel.Intelligence -= 5;
                        break;
                    case 11:
                        battleModel.Defense += 5;
                        break;
                    case 12:
                        battleModel.Defense -= 5;
                        break;
                }
            }
            return response;
        }
        public async Task<VoidServiceResponse> ApplyPassives()
        {
            var response = new VoidServiceResponse();
            var battleEnemy = _context.BattleModels
                .Include(c => c.Class).Include(c => c.Weapon).Include(c => c.Skill).Include(c => c.Armor).FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == false);
            var battleChar = _context.BattleModels
                .Include(c => c.Class).Include(c => c.Weapon).Include(c => c.Skill).Include(c => c.Armor)
                .FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == true);
            var bccls = ApplyClassPassive(battleChar!);
            var becls = ApplyClassPassive(battleEnemy!);
            var bcwpn = ApplyWeaponPassive(battleChar!);
            var bewpn = ApplyWeaponPassive(battleEnemy!);
            var bcamr = ApplyArmorPassive(battleChar!);
            var beamr = ApplyArmorPassive(battleEnemy!);
            await _context.SaveChangesAsync();
            response.Message = "The passive changes have been applied" + " / " + bccls.Message
            + " / " + becls.Message;
            return response;
        }
        // Attack 
        private int ChooseAttack(BattleModel attacker)
        {
            var rnd = new Random();
            var diff = attacker.Strength - attacker.Intelligence;
            if(attacker.Strength > attacker.Intelligence)
            {
                if(rnd.Next(1, 101) <= 50 + Math.Abs(diff))
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                if(rnd.Next(1, 101) <= 50 + Math.Abs(diff))
                {
                    return 0;
                }
                return 1;
            }
        }
        private int GetProtection(BattleModel model)
        {
            var armorFxs = _fxService.GetArmorFxById(model!.Armor!.Id);
            foreach(GetEffectDto fx in armorFxs.Result)
            {
                switch(fx.Id)
                {
                    case 14:
                        return 10;
                    case 15:
                        return 20;
                    case 16:
                        return 30;
                }
            }
            return 0;
        }
        private bool HasRiposte(BattleModel model)
        {
            var armorFxs = _fxService.GetArmorFxById(model!.Armor!.Id);
            foreach(GetEffectDto fx in armorFxs.Result)
            {
                if(fx.Id == 13)
                {
                    return true;
                }
            }
            return false;
        }
        
        private VoidServiceResponse ApplyWeaponActive(BattleModel attacker, BattleModel receiver)
        {
            var response = new VoidServiceResponse();
            response.Message = "The effects: ";
            var fxs = _fxService.GetWeaponFxById(attacker.Weapon!.Id).Result;
            foreach(GetEffectDto fx in fxs)
            {
                if(fx.Duration == 1)
                {
                    var data = new BattleModelEffect{BattleModelId = receiver.Id, EffectId = fx.Id};
                    _context.BattleModelEffects.Add(data);
                    _context.SaveChanges();
                    response.Message += $"/{fx.Name}/ ";
                }
            }
            if(response.Message == "The effects: ")
            {
                response.Message = $"No weapon effects were applied to {receiver.Name}";
            }
            else{
                response.Message += $"were applied to {receiver.Name}";
            }
            return response;
        }
        private VoidServiceResponse ApplySkillActive(BattleModel attacker, BattleModel receiver)
        {
            var response = new VoidServiceResponse();
            response.Message = "The effects: ";
            var fxs = _fxService.GetSkillFxById(attacker.Skill!.Id).Result;
            foreach(GetEffectDto fx in fxs)
            {
                if(fx.Duration == 1)
                {
                    var data = new BattleModelEffect{BattleModelId = receiver.Id, EffectId = fx.Id};
                    _context.BattleModelEffects.Add(data);
                    _context.SaveChanges();
                    response.Message += $"/{fx.Name}/ ";
                }
            }
            if(response.Message == "The effects: ")
            {
                response.Message = $"No weapon effects were applied to {receiver.Name}";
            }
            else{
                response.Message += $"were applied to {receiver.Name}";
            }
            return response;
        }
        private VoidServiceResponse UseAttack(BattleModel attacker, BattleModel receiver, int type)
        {
            var response = new VoidServiceResponse();
            int dmgRaw = 0;
            string aplyMsg = string.Empty;
            if(type == 1)
            { 
                dmgRaw = attacker.Weapon!.Damage;
                aplyMsg = ApplyWeaponActive(attacker, receiver).Message;
            }
            if(type == 0)
            {
                dmgRaw = attacker.Skill!.Damage;
                aplyMsg = ApplySkillActive(attacker, receiver).Message;
            }
            var receiverProt =  GetProtection(receiver);
            var dmg = dmgRaw * (100 - receiverProt) / 100;
            var blockedDmg = dmgRaw - dmg;
            if(HasRiposte(receiver))
            {
                var riposteDmg = dmg * 10 / 100;
                attacker.HitPoint -= riposteDmg;
                receiver.HitPoint -= dmg;
                response.Message = $"{attacker.Name} has attacked ${receiver.Name}, dealing {dmgRaw} points of damage of which {blockedDmg} were blocked and {riposteDmg} came back to the attacker. ";
                response.Message +=  aplyMsg;
                _context.SaveChanges();
                return response;
            }
            receiver.HitPoint -= dmg;
            response.Message = $"{attacker.Name} has used his weapon to attack ${receiver.Name}, dealing {dmgRaw} points of damage of which {blockedDmg} were blocked. ";
            response.Message +=  aplyMsg;
            _context.SaveChanges();
            return response;
        }
        // public VoidServiceResponse Attack(BattleModel attacker, BattleModel receiver)
        public VoidServiceResponse Attack()
        {
            var receiver = _context.BattleModels
                .Include(c => c.Class).Include(c => c.Weapon).Include(c => c.Skill).Include(c => c.Armor).FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == false);
            var attacker = _context.BattleModels
                .Include(c => c.Class).Include(c => c.Weapon).Include(c => c.Skill).Include(c => c.Armor)
                .FirstOrDefault
                (be => be.UserId == _httpContextService.GetCurrentUserId() & be.IsChar == true);
            var response = new VoidServiceResponse();
            if(ChooseAttack(attacker) == 1)
            {
                var Atkmsg = UseAttack(attacker, receiver, 1).Message;
                response.Message = Atkmsg;
                return response;
            }
            else
            {
                var Atkmsg = UseAttack(attacker, receiver, 0).Message;
                response.Message = Atkmsg;
                return response;
            }
        }
        // Fight
        public async Task<FightResponse> Fight()
        {
            throw new NotImplementedException();
        }
        public async Task<RoundResponse> FightOneRound()
        {
            throw new NotImplementedException();
            // test for commit on github desktop
        }

    }
}



