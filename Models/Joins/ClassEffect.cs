using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models.Joins
{
    public class ClassEffect
    {
        public int ClassId { get; set; }
        public Class? Class { get; set; }
        public int EffectId { get; set; }
        public Effect? Effect { get; set; }
    }
}