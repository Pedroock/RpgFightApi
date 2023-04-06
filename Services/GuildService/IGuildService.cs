using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.Enemy;
using RpgFight.Models;

namespace RpgFight.Services.GuildService
{
    public interface IGuildService
    {
        Task<ServiceResponse<List<GetEnemyDto>>> LookAtAllEnemies();
        Task<ServiceResponse<GetEnemyDto>> SelectEnemy(int id);
        Task<ServiceResponse<GetEnemyDto>> CreateEnemy(AddEnemyDto request);
        Task<ServiceResponse<GetEnemyDto>> LookAtEnemy();
        Task<ServiceResponse<GetEnemyDto>> EquipClass(int classId);
        Task<ServiceResponse<GetEnemyDto>> EquipWeapon(int weaponId);
        Task<ServiceResponse<GetEnemyDto>> EquipSkill(int skillId);
        Task<ServiceResponse<GetEnemyDto>> EquipArmor(int armorId);
        /*
        Task<ServiceResponse<GetEnemyDto>> UnselectEnemy();
        */
    }
}