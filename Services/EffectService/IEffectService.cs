using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Effect;

namespace RpgFight.Services.EffectService
{
    public interface IEffectService
    {
        Task<List<GetEffectDto>> GetWeaponFxById(int id);
        Task<List<GetEffectDto>> GetSkillFxById(int id);
        Task<List<GetEffectDto>> GetArmorFxById(int id);
    }
}