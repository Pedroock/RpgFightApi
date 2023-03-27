using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class Effect
    {
        public int Id {get;set;}
        public string Name { get; set; } = string.Empty;
        public int Intensity { get; set; }
        public bool Self { get; set; }
        public int Duration { get; set; }
        public List<ArmorEffect>? ArmorEffects { get; set; }
        public List<BattleCharacterEffect>? BattleCharacterEffects { get; set; }
        public List<BattleEnemyEffect>? BattleEnemyEffects { get; set; }
        public List<ClassEffect>? ClassEffects { get; set; }
        public List<SkillEffect>? SkillEffects { get; set; }
        public List<WeaponEffect>? WeaponEffects { get; set; }
    }
}