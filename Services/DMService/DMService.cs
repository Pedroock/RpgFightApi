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
using RpgFight.Dtos.Effect;

namespace RpgFight.Services.DMService
{
    public class DMService : IDMService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DMService(DataContext context, IMapper mapper)
        {   
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            var characters = await _context.Characters.ToListAsync();
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            response.Message = "This is a list of all characters";
            return response;
        }

        public async Task<ServiceResponse<List<GetClassDto>>> GetAllClasses()
        {
            var response = new ServiceResponse<List<GetClassDto>>();
            var classes = await _context.Classs.ToListAsync();
            List<GetClassDto> classDtoList = new List<GetClassDto>();
            foreach(Class c in classes)
            {
                var classDto = _mapper.Map<GetClassDto>(c)!;
                var classEffects = _context.ClassEffects.Where(ce => ce.ClassId == c.Id).ToList();
                List<GetEffectDto> fxList = new List<GetEffectDto>();
                foreach(ClassEffect ce in classEffects)
                {
                    fxList.Add(_mapper.Map<GetEffectDto>(
                        await _context.Effects.FirstOrDefaultAsync(e => e.Id == ce.EffectId)
                    ));
                }
                classDto.Effects = fxList;
                classDtoList.Add(classDto);
            }
            response.Data = classDtoList;
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
            response.Message = "This is a list of all effects";
            return response;
        }
    }
}