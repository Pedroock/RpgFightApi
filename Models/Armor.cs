using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class Armor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ArmorEffect>? ArmorEffects { get; set; }
        public List<Character>? Characters {get;set;} 
    }
}