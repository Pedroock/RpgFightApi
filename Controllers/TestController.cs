using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgFight.Models;
using RpgFight.Models.Joins;
using RpgFight.Dtos.Character;
using RpgFight.Dtos.Effect;

namespace RpgFight.Controllers
{
    [ApiController]
    //[Authorize(Policy = "DungeonMaster")]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost("Auth test")]
        public ActionResult<GetCharacterDto> Test()
        {
            return Ok();
        }
    }
}