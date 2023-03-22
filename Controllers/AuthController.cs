using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgFight.Services.AuthService;
using RpgFight.Models;
using RpgFight.Dtos.User;

namespace RpgFight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(UserRegisterDto request)
        {
            return Ok(await _auth.Register(request));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login (UserLoginDto request)
        {
            return Ok(await _auth.Login(request));
        }
    }
}