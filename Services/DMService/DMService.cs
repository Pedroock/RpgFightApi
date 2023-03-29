using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgFight.Data;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Skill;
using RpgFight.Dtos.Weapon;
using RpgFight.Models;
using RpgFight.Models.Joins;
using AutoMapper;
using RpgFight.Dtos.Character;
using RpgFight.Dtos.Class;
using RpgFight.Dtos.Enemy;
using RpgFight.Dtos.Effect;
using RpgFight.Services.EffectService;
using System.Security.Claims;

namespace RpgFight.Services.DMService
{
    public class DMService : IDMService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEffectService _fxService;
        private readonly IHttpContextAccessor _httpContext;
        public DMService(DataContext context, IMapper mapper, IEffectService fxService, IHttpContextAccessor httpContext)
        {   
            _context = context;
            _mapper = mapper;
            _fxService = fxService;
            _httpContext = httpContext;
        }
        // Needed Methods
        private int GetCurrentUserId() => int.Parse(
            _httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
        // GetAll
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            var characters = await _context.Characters.Where(
                c => c.UserId == GetCurrentUserId()).ToListAsync();
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            response.Message = "This is a list of all your characters";
            return response;
        }

        public async Task<ServiceResponse<List<GetEnemyDto>>> GetAllEnemies()
        {
            var response = new ServiceResponse<List<GetEnemyDto>>();
            var enemies = await _context.Enemies.ToListAsync();
            response.Data = enemies.Select(c => _mapper.Map<GetEnemyDto>(c)).ToList();
            response.Message = "This is a list of all enemies";
            return response;
        }

        public async Task<ServiceResponse<List<GetClassDto>>> GetAllClasses()
        {
            var response = new ServiceResponse<List<GetClassDto>>();
            var classes = await _context.Classs.ToListAsync();
            response.Data = classes.Select(c => _mapper.Map<GetClassDto>(c)).ToList();
            response.Message = "This is a list of all classes";
            return response;
        }

        public async Task<ServiceResponse<List<GetWeaponDto>>> GetAllWeapons()
        {
            var response = new ServiceResponse<List<GetWeaponDto>>();
            var weapons = await _context.Weapons.ToListAsync();
            List<GetWeaponDto> weaponDtoList = new List<GetWeaponDto>();
            foreach(Weapon weapon in weapons)
            {
                var weaponDto = _mapper.Map<GetWeaponDto>(weapon);
                var weaponEffects = _context.WeaponEffects.Where(we => we.WeaponId == weapon.Id);
                List<GetEffectDto> fxList = new List<GetEffectDto>();
                foreach(WeaponEffect we in weaponEffects)
                {
                    fxList.Add(_mapper.Map<GetEffectDto>(
                        await _context.Effects.FirstOrDefaultAsync(e => e.Id == we.EffectId)
                    ));
                }
                weaponDto.Effects = fxList;
                weaponDtoList.Add(weaponDto);
            }
            response.Data = weaponDtoList;
            response.Message = "This is a list of all weapons";
            return response;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills()
        {
            var response = new ServiceResponse<List<GetSkillDto>>();
            var skills = await _context.Skills.ToListAsync();
            List<GetSkillDto> skillDtoList = new List<GetSkillDto>(); 
            foreach(Skill skill in skills)
            {
                var skillDto = _mapper.Map<GetSkillDto>(skill);
                var skillEffects = _context.SkillEffects.Where(se => se.SkillId == skill.Id);
                List<GetEffectDto> fxList = new List<GetEffectDto>();
                foreach(SkillEffect se in skillEffects)
                {
                    fxList.Add(_mapper.Map<GetEffectDto>(
                        await _context.Effects.FirstOrDefaultAsync(e => e.Id == se.EffectId)
                    ));
                }
                skillDto.Effects = fxList;
                skillDtoList.Add(skillDto);
            }
            response.Data = skillDtoList;
            response.Message = "This is a list of all weapons";
            return response;
        }

        public async Task<ServiceResponse<List<GetArmorDto>>> GetAllArmors()
        {
            var response = new ServiceResponse<List<GetArmorDto>>();
            var armors = await _context.Armors.ToListAsync();
            List<GetArmorDto> armorDtoList = new List<GetArmorDto>();
            foreach(Armor armor in armors)
            {
                var armorDto = _mapper.Map<GetArmorDto>(armor);
                var armorEffects = _context.ArmorEffects.Where(ae => ae.ArmorId == armor.Id);
                List<GetEffectDto> fxList = new List<GetEffectDto>();
                foreach(ArmorEffect ae in armorEffects)
                {
                    fxList.Add(_mapper.Map<GetEffectDto>(
                        await _context.Effects.FirstOrDefaultAsync(e => e.Id == ae.EffectId)
                    ));
                }
                armorDto.Effects = fxList;
                armorDtoList.Add(armorDto);
            }
            response.Data = armorDtoList;
            response.Message = "This is a list of all armors";
            return response;
        }

        public async Task<ServiceResponse<List<GetEffectDto>>> GetAllEffects()
        {
            var response = new ServiceResponse<List<GetEffectDto>>();
            var effects = await _context.Effects.ToListAsync();
            response.Data = effects.Select(e => _mapper.Map<GetEffectDto>(e)).ToList();
            response.Message = "This is a list of all effects. If 'self=true', the effect is dealt on you, otherwise it will be dealt upon your enemy";
            return response;
        }
        // GetById
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;
        }
        public async Task<ServiceResponse<GetClassDto>> GetClassById(int id)
        {
            var response = new ServiceResponse<GetClassDto>();
            var clas = await _context.Classs.FirstOrDefaultAsync(c => c.Id == id);
            response.Data = _mapper.Map<GetClassDto>(clas);
            return response; 
        }
        public async Task<ServiceResponse<GetWeaponDto>> GetWeaponById(int id)
        {
            var response = new ServiceResponse<GetWeaponDto>();
            var weapon = await _context.Weapons.FirstOrDefaultAsync(c => c.Id == id);
            var weaponDto = _mapper.Map<GetWeaponDto>(weapon);
            weaponDto.Effects = await _fxService.GetWeaponFxById(weapon!.Id);
            response.Data = weaponDto;
            return response; 
        }
        public async Task<ServiceResponse<GetSkillDto>> GetSkillById(int id)
        {
            var response = new ServiceResponse<GetSkillDto>();
            var skill = await _context.Skills.FirstOrDefaultAsync(c => c.Id == id);
            var skillDto = _mapper.Map<GetSkillDto>(skill);
            skillDto.Effects = await _fxService.GetSkillFxById(skill!.Id);
            response.Data = skillDto;
            return response; 
        }
        public async Task<ServiceResponse<GetArmorDto>> GetArmorById(int id)
        {
            var response = new ServiceResponse<GetArmorDto>();
            var armor = await _context.Armors.FirstOrDefaultAsync(c => c.Id == id);
            var armorDto = _mapper.Map<GetArmorDto>(armor);
            armorDto.Effects = await _fxService.GetArmorFxById(armor!.Id);
            response.Data = armorDto;
            return response; 
        }
        public async Task<ServiceResponse<GetEffectDto>> GetEffectById(int id)
        {
            var response = new ServiceResponse<GetEffectDto>();
            var fx = await _context.Effects.FirstOrDefaultAsync(c => c.Id == id);
            response.Data = _mapper.Map<GetEffectDto>(fx);
            return response; 
        }
    }
}