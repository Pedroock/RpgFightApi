using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Weapon;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Skill;
using RpgFight.Dtos.Character;
using RpgFight.Dtos.Effect;
using RpgFight.Dtos.Class;


namespace RpgFight.Services.DMService
{
    public interface IDMService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<List<GetClassDto>>> GetAllClasses();
        Task<ServiceResponse<List<GetWeaponDto>>> GetAllWeapons();
        Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills();
        Task<ServiceResponse<List<GetArmorDto>>> GetAllArmors();
        Task<ServiceResponse<List<GetEffectDto>>> GetAllEffects();
    }
}