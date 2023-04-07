using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Services.ArenaService
{
    public interface IArenaService
    {
        Task<FightResponse> Fight();
        Task<ServiceResponse<bool>> SetUpBattle();
    }
}