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
using RpgFight.Services.DMService;

namespace RpgFight.Controllers
{
    [ApiController]
    [Authorize(Policy = "DungeonMaster")]
    [Route("api/[controller]")]
    public class DungeonMasterController : ControllerBase
    {
        private readonly IDMService _dmService;
        public DungeonMasterController(IDMService dmService)
        {
            _dmService = dmService;
        }
        [HttpPost("Add Armor")]
        public async Task<ActionResult<ServiceResponse<GetArmorDto>>> AddArmor(AddArmorDto request)
        {
            return Ok(await _dmService.AddArmor(request));
        }
    }
}