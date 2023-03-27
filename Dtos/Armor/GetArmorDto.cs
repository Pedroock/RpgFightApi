using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.Effect;


namespace RpgFight.Dtos.Armor
{
    public class GetArmorDto
    {
        public string Name { get; set; } = string.Empty;
        public int Price {get;set;}
        public List<GetEffectDto>? Effects { get; set; }
    }
}