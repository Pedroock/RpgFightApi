using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgFight.Models;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Skill;
using RpgFight.Dtos.Weapon;
using RpgFight.Dtos.Character;
using RpgFight.Dtos.Effect;
using RpgFight.Dtos.Class;
using RpgFight.Services.DMService;

namespace RpgFight.Controllers
{
    [ApiController]
    //[Authorize(Policy = "DungeonMaster")]
    [Route("api/[controller]")]
    public class DungeonMasterController : ControllerBase
    {
        private readonly IDMService _dmService;
        public DungeonMasterController(IDMService dmService)
        {
            _dmService = dmService;
        }
        // GetAll
        [HttpGet("Get All Characters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        {
            return Ok(await _dmService.GetAllCharacters());
        }

        [HttpGet("Get All Classes")]
        public async Task<ActionResult<ServiceResponse<List<GetClassDto>>>> GetAllClasses()
        {
            return Ok(await _dmService.GetAllClasses());
        }
        
        [HttpGet("Get All Weapons")]
        public async Task<ActionResult<ServiceResponse<List<GetWeaponDto>>>> GetAllWeapons()
        {
            return Ok(await _dmService.GetAllWeapons());
        }
        
        [HttpGet("Get All Skills")]
        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> GetAllSkills()
        {
            return Ok(await _dmService.GetAllSkills());
        }
        
        [HttpGet("Get All Armors")]
        public async Task<ActionResult<ServiceResponse<List<GetArmorDto>>>> GetAllArmors()
        {
            return Ok(await _dmService.GetAllArmors());
        }
        
        [HttpGet("Get All Effects")]
        public async Task<ActionResult<ServiceResponse<List<GetEffectDto>>>> GetAllEffects()
        {
            return Ok(await _dmService.GetAllEffects());
        }
        // GetById
        [HttpGet("Get Character By Id")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id)
        {
            return Ok(await _dmService.GetCharacterById(id));
        }
        [HttpGet("Get Class By Id")]
        public async Task<ActionResult<ServiceResponse<GetClassDto>>> GetClassById(int id)
        {
            return Ok(await _dmService.GetClassById(id));
        }
        [HttpGet("Get Weapon By Id")]
        public async Task<ActionResult<ServiceResponse<GetWeaponDto>>> GetWeaponById(int id)
        {
            return Ok(await _dmService.GetWeaponById(id));
        }
        [HttpGet("Get Skill By Id")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> GetSkillById(int id)
        {
            return Ok(await _dmService.GetSkillById(id));
        }
        [HttpGet("Get Armor By Id")]
        public async Task<ActionResult<ServiceResponse<GetArmorDto>>> GetArmorById(int id)
        {
            return Ok(await _dmService.GetArmorById(id));
        }
        [HttpGet("Get Effect By Id")]
        public async Task<ActionResult<ServiceResponse<GetEffectDto>>> GetEffectById(int id)
        {
            return Ok(await _dmService.GetEffectById(id));
        }
    }
}