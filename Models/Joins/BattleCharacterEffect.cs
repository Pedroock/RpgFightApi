using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Models
{
    public class BattleCharacterEffect
    {
        public int BattleCharacterId { get; set; }
        public BattleCharacter? BattleCharacter { get; set; }
        public int EffectId { get; set; }
        public Effect? Effect { get; set; }
    }
}