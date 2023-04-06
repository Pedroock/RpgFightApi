using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgFight.Services.GuildService;
using RpgFight.Models;
using RpgFight.Dtos.Enemy;
using Microsoft.AspNetCore.Authorization;

namespace RpgFight.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class GuildController : ControllerBase
    {
        private readonly IGuildService _guildService;
        public GuildController(IGuildService guildService)
        {
            _guildService = guildService;
        }

        [HttpGet("Look At All Enemies")]
        public async Task<ActionResult<ServiceResponse<List<GetEnemyDto>>>> LookAtAllEnemies()
        {
            return Ok(await _guildService.LookAtAllEnemies());
        }

        [HttpPost("Select Enemy")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> SelectEnemy(int id)
        {
            return Ok(await _guildService.SelectEnemy(id));
        }

        [HttpPost("Create Enemy")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> CreateEnemy(AddEnemyDto request)
        {
            return Ok(await _guildService.CreateEnemy(request));
        }

        [HttpGet("Look At Enemy")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> LookAtEnemy()
        {
            return Ok(await _guildService.LookAtEnemy());
        }

        [HttpPost("Equip Class")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> EquipClass(int classId)
        {
            return Ok(await _guildService.EquipClass(classId));
        }

        [HttpPost("Equip Weapon")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> EquipWeapon(int weaponId)
        {
            return Ok(await _guildService.EquipWeapon(weaponId));
        }

        [HttpPost("Equip Skill")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> EquipSkill(int skillId)
        {
            return Ok(await _guildService.EquipSkill(skillId));
        }

        [HttpPost("Equip Armor")]
        public async Task<ActionResult<ServiceResponse<GetEnemyDto>>> EquipArmor(int armorId)
        {
            return Ok(await _guildService.EquipArmor(armorId));
        }
    }
}