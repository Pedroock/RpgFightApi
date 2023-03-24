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
            var characters = await _context.Characters
                .ToListAsync();
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            response.Message = "This is a list of all characters";
            return response;
        }

        public async Task<ServiceResponse<List<GetClassDto>>> GetAllClasses()
        {
            var response = new ServiceResponse<List<GetClassDto>>();
            var classes = await _context.Classs
                .ToListAsync();
            response.Data = classes.Select(c => _mapper.Map<GetClassDto>(c)).ToList();
            response.Message = "This is a list of all class";
            return response;
        }

        public async Task<ServiceResponse<List<GetWeaponDto>>> GetAllWeapons()
        {
            var response = new ServiceResponse<List<GetWeaponDto>>();
            var weapons = await _context.Weapons
                .ToListAsync();
            response.Data = weapons.Select(w => _mapper.Map<GetWeaponDto>(w)).ToList();
            response.Message = "This is a list of all weapons";
            return response;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills()
        {
            var response = new ServiceResponse<List<GetSkillDto>>();
            var skills = await _context.Skills
                .ToListAsync();
            response.Data = skills.Select(s => _mapper.Map<GetSkillDto>(s)).ToList();
            response.Message = "This is a list of all weapons";
            return response;
        }

        public async Task<ServiceResponse<List<GetArmorDto>>> GetAllArmors()
        {
            var response = new ServiceResponse<List<GetArmorDto>>();
            var armors = await _context.Armors
                .ToListAsync();
            response.Data = armors.Select(a => _mapper.Map<GetArmorDto>(a)).ToList();
            response.Message = "This is a list of all armors";
            return response;
        }

        public async Task<ServiceResponse<List<GetEffectDto>>> GetAllEffects()
        {
            var response = new ServiceResponse<List<GetEffectDto>>();
            var effects = await _context.Effects
                .ToListAsync();
            response.Data = effects.Select(e => _mapper.Map<GetEffectDto>(e)).ToList();
            response.Message = "This is a list of all effects";
            return response;
        }
    }
}