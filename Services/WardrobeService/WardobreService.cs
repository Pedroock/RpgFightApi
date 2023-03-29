using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Character;
using RpgFight.Services.EffectService;
using AutoMapper;
using RpgFight.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace RpgFight.Services.WardrobeService
{
    public class WardobreService : IWardrobeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEffectService _fxService;
        private readonly IHttpContextAccessor _httpContext;
        public WardobreService(DataContext context, IMapper mapper, IEffectService fxService, IHttpContextAccessor httpContext)
        {   
            _context = context;
            _mapper = mapper;
            _fxService = fxService;
            _httpContext = httpContext;
        }
        // Needed Methods
        private int GetCurrentUserId() => int.Parse(
            _httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
        // Character Methods
        public async Task<ServiceResponse<GetCharacterDto>> CreateCharacter(AddCharacterDto request)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetCurrentUserId());
            if(request.Strength + request.Defense + request.Intelligence != 30 | request.Defense < 5 | request.Strength < 5 | request.Intelligence < 5)
            {
                response.Success = false;
                response.Message = "The sum of your stats can't be greater than 30 and all stats must be greater than 5";
                return response;
            }
            var character = _mapper.Map<Character>(request);
            character.User = user;
            character.UserId = GetCurrentUserId();
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterDto>(character);
            response.Message = $"You have created {character.Name}, now equip some gear";
            return response;
        }

        public Task<ServiceResponse<GetCharacterDto>> LookAtCharacter()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> EquipClass(int classId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> EquipWeapon(int weaponId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> EquipSkill(int skillId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> EquipArmor(int armorId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(AddCharacterDto request)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<string>> DeleteCharacter()
        {
            throw new NotImplementedException();
        }
    }
}