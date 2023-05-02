using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;
using RpgFight.Dtos.Effect;

namespace RpgFight.Dtos.Skill
{
    public class GetSkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public List<GetEffectDto>? Effects { get; set; }
    }
}