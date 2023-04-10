using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class BattleCharacter
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public int HitPoint {get;set;}
        public int Strength {get;set;}
        public int Intelligence {get;set;}
        public int Defense {get;set;}
        public Class? Class {get;set;}
        public Weapon? Weapon {get;set;}
        public Armor? Armor { get; set; }
        public Skill? Skill { get; set; }
        public List<BattleCharacterEffect>? BattleCharacterEffects { get; set; }
        public User? User {get;set;}
        public int UserId { get; set; }
    }
}