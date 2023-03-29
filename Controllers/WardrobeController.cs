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
    }
}