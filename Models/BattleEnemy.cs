using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class BattleEnemy
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public int HitPoint {get;set;}
        public int Strength {get;set;}
        public int Intelligence {get;set;}
        public int Defense {get;set;}
        public Class? Class {get;set;}
        public Weapon? Weapon {get;set;}
        public Armor? Armor {get;set;}
        public Skill? Skill { get; set; }
        public List<BattleEnemyEffect>? BattleEnemyEffects {get;set;}
        public BattleCharacter? BattleCharacter {get;set;}
        public int BattleCharacterId { get; set; }
    }
}