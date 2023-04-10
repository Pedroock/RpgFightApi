using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Services.ArenaService
{
    public interface IArenaService
    {
        Task<VoidServiceResponse> SetUpBattle();
        Task<VoidServiceResponse> ApplyPassives();
        Task<FightResponse> Fight();
    }
}