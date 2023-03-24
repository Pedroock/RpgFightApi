using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Models.Joins
{
    public class WeaponEffect
    {
        public int WeaponId { get; set; }
        public Weapon? Weapon { get; set; }
        public int EffectId { get; set; }
        public Effect? Effect { get; set; }
    }
}