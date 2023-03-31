using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgFight.Services.WardrobeService;
using RpgFight.Models;
using RpgFight.Dtos.Character;
using Microsoft.AspNetCore.Authorization;

namespace RpgFight.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class WardrobeController : ControllerBase
    {
        private readonly IWardrobeService _wardrobe;
        public WardrobeController(IWardrobeService wardrobe)
        {
            _wardrobe = wardrobe;
        }

        [HttpPost("Create Character")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> CreateCharacter(AddCharacterDto request)
        {
            return Ok(await _wardrobe.CreateCharacter(request));
        }

        [HttpGet("Look At Character")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> LookAtCharacter()
        {
            return Ok(await _wardrobe.LookAtCharacter());
        }

        [HttpPost("Equip Class")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> EquipClass(int classId)
        {
            return Ok(await _wardrobe.EquipClass(classId));
        }

        [HttpPost("Equip Weapon")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> EquipWeapon(int weaponId)
        {
            return Ok(await _wardrobe.EquipWeapon(weaponId));
        }

        [HttpPost("Equip Armor")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> EquipArmor(int armorId)
        {
            return Ok(await _wardrobe.EquipArmor(armorId));
        }

        [HttpPost("Equip Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> EquipSkill(int skillId)
        {
            return Ok(await _wardrobe.EquipSkill(skillId));
        }

        [HttpPut("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(AddCharacterDto update)
        {
            return Ok(await _wardrobe.UpdateCharacter(update));
        }

        [HttpDelete("Delete Character")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteCharacter()
        {
            return Ok(await _wardrobe.DeleteCharacter());
        }

    }
}