using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Dtos.Skill
{
    public class AddSkillDto
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public int EffectId {get;set;}
        public int Price { get; set; }
    }
}