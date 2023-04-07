using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgFight.Services.ArenaService;
using RpgFight.Models;

namespace RpgFight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ArenaController : ControllerBase
    {
        private readonly IArenaService _arenaService;
        public ArenaController(IArenaService arenaService)
        {
            _arenaService = arenaService;
        }
        [HttpPost("Set up battle test")]
        public async Task<ActionResult<ServiceResponse<bool>>> SetUpFight()
        {
            return Ok(await _arenaService.SetUpBattle());
        }
    }
}