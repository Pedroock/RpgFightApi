using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models.Joins
{
    public class RebootEffect
    {
        public int Id { get; set; }
        public int BattleModelId { get; set; }
        public int EffectId { get; set; }
    }
}