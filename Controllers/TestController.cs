using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RpgFight.Controllers
{
    [ApiController]
    [Authorize(Policy = "DungeonMaster")]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost("Auth test")]
        public ActionResult<string> Test()
        {
            return Ok("It worked");
        }
    }
}