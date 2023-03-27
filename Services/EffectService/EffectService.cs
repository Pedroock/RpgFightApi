using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.Effect;
using RpgFight.Models;
using RpgFight.Models.Joins;
using RpgFight.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace RpgFight.Services.EffectService
{
    public class EffectService : IEffectService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EffectService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetEffectDto>> GetArmorFxById(int id)
        {
            var armorFxs = await _context.ArmorEffects.Where(ae => ae.ArmorId == id).ToListAsync();
            List<GetEffectDto> fxs = new List<GetEffectDto>();
            foreach(ArmorEffect ae in armorFxs)
            {
                var fxModel = await _context.Effects.FirstOrDefaultAsync(e => e.Id == ae.EffectId);
                var fx = _mapper.Map<GetEffectDto>(fxModel);
                fxs.Add(fx!);
            }
            return fxs;
        }

        public async Task<List<GetEffectDto>> GetSkillFxById(int id)
        {
            var skillFxs = await _context.SkillEffects.Where(ae => ae.SkillId == id).ToListAsync();
            List<GetEffectDto> fxs = new List<GetEffectDto>();
            foreach(SkillEffect ae in skillFxs)
            {
                var fxModel = await _context.Effects.FirstOrDefaultAsync(e => e.Id == ae.EffectId);
                var fx = _mapper.Map<GetEffectDto>(fxModel);
                fxs.Add(fx!);
            }
            return fxs;
        }

        public async Task<List<GetEffectDto>> GetWeaponFxById(int id)
        {
            var weaponFxs = await _context.WeaponEffects.Where(ae => ae.WeaponId == id).ToListAsync();
            List<GetEffectDto> fxs = new List<GetEffectDto>();
            foreach(WeaponEffect ae in weaponFxs)
            {
                var fxModel = await _context.Effects.FirstOrDefaultAsync(e => e.Id == ae.EffectId);
                var fx = _mapper.Map<GetEffectDto>(fxModel);
                fxs.Add(fx!);
            }
            return fxs;
        }
    }
}