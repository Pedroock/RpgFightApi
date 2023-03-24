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
        public async Task<ServiceResponse<GetArmorDto>> AddArmor(AddArmorDto request)
        {
            var response = new ServiceResponse<GetArmorDto>();
            var effect = await _context.Effects.FirstOrDefaultAsync(e => e.Id == request.EffectId);
            if(effect is null)
            {
                response.Success = false;
                response.Message = "Selected effected was not found";
                return response;
            }
            var armor = new Armor
            {
                Name = request.Name,
                // Effect = effect,             consertar efeitos NAO ESQUCEEEE
                Price = request.Price,
            };
            _context.Armors.Add(armor);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetArmorDto>(armor);
            response.Message = $"The  {armor.Name}  has been created";
            return response;
        }

        public Task<ServiceResponse<GetSkillDto>> AddSkill(AddSkillDto request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetWeaponDto>> AddWeapon(AddWeaponDto request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetArmorDto>>> DeleteArmor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetSkillDto>>> DeleteSkill(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetWeaponDto>>> DeleteWeapon(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetArmorDto>>> GetAllArmors()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetWeaponDto>>> GetAllWeapons()
        {
            throw new NotImplementedException();
        }
    }
}