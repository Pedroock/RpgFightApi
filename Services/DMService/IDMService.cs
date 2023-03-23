using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Weapon;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Skill;

namespace RpgFight.Services.DMService
{
    public interface IDMService
    {
        Task<ServiceResponse<List<GetWeaponDto>>> GetAllWeapons();
        Task<ServiceResponse<GetWeaponDto>> AddWeapon(AddWeaponDto request);
        Task<ServiceResponse<List<GetWeaponDto>>> DeleteWeapon(int id);
        Task<ServiceResponse<List<GetArmorDto>>> GetAllArmors();
        Task<ServiceResponse<GetArmorDto>> AddArmor(AddArmorDto request);
        Task<ServiceResponse<List<GetArmorDto>>> DeleteArmor(int id);
        Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills();
        Task<ServiceResponse<GetSkillDto>> AddSkill(AddSkillDto request);
        Task<ServiceResponse<List<GetSkillDto>>> DeleteSkill(int id);
    }
}