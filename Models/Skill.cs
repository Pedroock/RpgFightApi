using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public List<SkillEffect>? SkillEffects {get;set;}
        public int Price { get; set; }
        public List<Character>? Characters {get;set;} 
    }
}