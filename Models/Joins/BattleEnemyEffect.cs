using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Models.Joins
{
    public class BattleEnemyEffect
    {
        public int BattleEnemyId { get; set; }
        public BattleEnemy? BattleEnemy { get; set; }
        public int EffectId { get; set; }
        public Effect? Effect { get; set; }
    }
}