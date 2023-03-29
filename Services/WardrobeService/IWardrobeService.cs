using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Character;

namespace RpgFight.Services.WardrobeService
{
    public interface IWardrobeService
    {
        Task<ServiceResponse<GetCharacterDto>> CreateCharacter(AddCharacterDto request);
        Task<ServiceResponse<GetCharacterDto>> LookAtCharacter();
        Task<ServiceResponse<GetCharacterDto>> EquipClass(int classId);
        Task<ServiceResponse<GetCharacterDto>> EquipWeapon(int weaponId);
        Task<ServiceResponse<GetCharacterDto>> EquipSkill(int skillId);
        Task<ServiceResponse<GetCharacterDto>> EquipArmor(int armorId);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(AddCharacterDto request);
    }
}