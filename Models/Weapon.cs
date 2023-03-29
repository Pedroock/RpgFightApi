using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class Weapon
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public int Damage {get;set;}
        public List<WeaponEffect>? WeaponEffects { get; set; }
        public List<Character>? Characters {get;set;} 
    }
}