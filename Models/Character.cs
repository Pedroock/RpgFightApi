using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class Character
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public int HitPoint {get;set;} = 100;
        public int Strength {get;set;} = 10;
        public int Intelligence {get;set;} = 10;
        public int Defense {get;set;} = 10;
        public int Level {get;set;} = 1;
        public int Money { get; set; } = 100;
        public User? User {get;set;}
        public Class? Class {get;set;}
        public Weapon? Weapon {get;set;}
        public Armor? Armor { get; set; }
        public Skill? Skill { get; set; }
        public BattleCharacter? BattlCharacter {get;set;}
    }
}