using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Character;
using RpgFight.Services.EffectService;
using RpgFight.Services.DMService;
using AutoMapper;
using RpgFight.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace RpgFight.Services.WardrobeService
{
    public class WardobreService : IWardrobeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEffectService _fxService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IDMService _dmService;
        public WardobreService(DataContext context, IMapper mapper, IEffectService fxService, IHttpContextAccessor httpContext, IDMService dmService)
        {   
            _context = context;
            _mapper = mapper;
            _fxService = fxService;
            _httpContext = httpContext;
            _dmService = dmService;
        }
        // Needed Methods
        private int GetCurrentUserId() => int.Parse(
            _httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
        private async Task<ServiceResponse<Character>> GetCurrentCharacter() 
        {
            var response = new ServiceResponse<Character>();
            var c = await _context.Characters.FirstOrDefaultAsync(c => c.UserId == GetCurrentUserId());
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
        // Character Methods
        public async Task<ServiceResponse<GetCharacterDto>> CreateCharacter(AddCharacterDto request)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetCurrentUserId());
            if(request.Strength + request.Defense + request.Intelligence != 30 | request.Defense < 5 | request.Strength < 5 | request.Intelligence < 5)
            {
                response.Success = false;
                response.Message = "The sum of your stats can't be greater than 30 and all stats must be greater than 5";
                return response;
            }
            var character = _mapper.Map<Character>(request);
            character.User = user;
            character.UserId = GetCurrentUserId();
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterDto>(character);
            response.Message = $"You have created {character.Name}, now equip some gear";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> LookAtCharacter()
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var c = await _context.Characters
                .Include(c => c.Class).Include(c => c.Armor).Include(c => c.Weapon).Include(c => c.Skill)
                .FirstOrDefaultAsync(c => c.UserId == GetCurrentUserId());
            if(c is null)
            {
                response.Success = false;
                response.Message = "You have no character, create one first";
                return response;
            }
            response.Data = _mapper.Map<GetCharacterDto>(c);
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> EquipClass(int classId)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var cls = _dmService.GetClassModelById(classId);
            if (cls.Result.Success == false)
            {
                response.Success = false;
                response.Message = cls.Result.Message;
                return response;
            }
            var c = await GetCurrentCharacter();
            if (c.Data is null)
            {
                response.Success = false;
                response.Message = c!.Message;
                return response;
            }
            c.Data!.Class = cls.Result.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your new class is {cls!.Result.Data!.Name}";
            response.Data = LookAtCharacter().Result.Data;
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> EquipWeapon(int weaponId)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var weapon = _dmService.GetWeaponModelById(weaponId);
            if (weapon.Result.Data is null)
            {
                response.Success = false;
                response.Message = weapon.Result.Message;
                return response;
            }
            var c = await GetCurrentCharacter();
            if (c.Data is null)
            {
                response.Success = false;
                response.Message = c!.Message;
                return response;
            }
            c.Data!.Weapon = weapon.Result.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your new weapon is {weapon!.Result.Data!.Name}";
            response.Data = LookAtCharacter().Result.Data;
            return response;
        }
        public async Task<ServiceResponse<GetCharacterDto>> EquipArmor(int armorId)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var armor = await _dmService.GetArmorModelById(armorId);
            if(armor is null)
            {
                response.Success = false;
                response.Message = armor!.Message;
                return response;
            }
            var c = await GetCurrentCharacter();
            if (c.Data is null)
            {
                response.Success = false;
                response.Message = c!.Message;
                return response;
            }
            c.Data!.Armor = armor.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your new armor is {armor!.Data!.Name}";
            response.Data = LookAtCharacter().Result.Data;
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> EquipSkill(int skillId)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var skill = await _dmService.GetSkillModelById(skillId);
            if(skill is null)
            {
                response.Success = false;
                response.Message = skill!.Message;
                return response;
            }
            var c = await GetCurrentCharacter();
            if (c.Data is null)
            {
                response.Success = false;
                response.Message = c!.Message;
                return response;
            }
            c.Data!.Skill = skill.Data;
            await _context.SaveChangesAsync();
            response.Message = $"Your new skill is {skill!.Data!.Name}";
            response.Data = LookAtCharacter().Result.Data;
            return response;
        }


        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(AddCharacterDto request)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            if(request.Strength + request.Defense + request.Intelligence != 30 | request.Defense < 5 | request.Strength < 5 | request.Intelligence < 5)
            {
                response.Success = false;
                response.Message = "The sum of your stats can't be greater than 30 and all stats must be greater than 5";
                return response;
            }
            var c = await GetCurrentCharacter();
            if (c.Data is null)
            {
                response.Success = false;
                response.Message = c!.Message;
                return response;
            }
            c.Data!.Name = request.Name;
            c.Data!.Intelligence = request.Intelligence;
            c.Data!.Strength = request.Strength;
            c.Data!.Defense = request.Defense;
            await _context.SaveChangesAsync();
            response.Message = "You have updated your character";
            response.Data = LookAtCharacter().Result.Data;
            return response;
        }
        public async Task<ServiceResponse<string>> DeleteCharacter()
        {
            var response = new ServiceResponse<string>();
            var c = await GetCurrentCharacter();
            if (c.Data is null)
            {
                response.Success = false;
                response.Message = c!.Message;
                return response;
            }
            var name = c.Data!.Name;
            _context.Characters.Remove(c.Data!);
            await _context.SaveChangesAsync();
            response.Message = "Your character has been deleted";
            response.Data = $"{name}";
            return response;
        }
    }
}