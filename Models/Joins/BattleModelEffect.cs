using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models.Joins
{
    public class BattleModelEffect
    {
        public int BattleModelId { get; set; }
        public BattleModel? BattleModel { get; set; }
        public int EffectId { get; set; }
        public Effect? Effect { get; set; }
    }
}