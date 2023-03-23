using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Dtos.Skill
{
    public class GetSkillDto
    {
        
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public Effect? Effect {get;set;}
        public int Price { get; set; }
    }
}