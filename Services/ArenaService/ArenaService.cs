using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Data;
using RpgFight.Models;
using RpgFight.Services.DMService;
using RpgFight.Services.EffectService;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RpgFight.Services.HttpContextService;
using AutoMapper;

namespace RpgFight.Services.ArenaService
{
    public class ArenaService : IArenaService
    {
        private readonly DataContext _context;
        private readonly IEffectService _fxService;
        private readonly IDMService _dmService;
        private readonly IHttpContextService _httpContextService;
        private readonly IMapper _mapper;
        public ArenaService(DataContext context, IDMService dmService, IEffectService fxService, IHttpContextService httpContextService, IMapper mapper)
        {
            _context = context;
            _httpContextService = httpContextService;
            _dmService = dmService;
            _fxService = fxService;
            _mapper = mapper;
        }
        // Needed Methods 

        public async Task<ServiceResponse<bool>> SetUpBattle()
        {
            
        }
        // Fight Methods
        public async Task<FightResponse> Fight()
        {
            throw new NotImplementedException();
        }
        public async Task<RoundResponse> FightOneRound()
        {
            throw new NotImplementedException();
        }

    }
}