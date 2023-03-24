using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Models.Joins
{
    public class SkillEffect
    {
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
        public int EffectId { get; set; }
        public Effect? Effect { get; set; }
    }
}