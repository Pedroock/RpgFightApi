using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.Effect;

namespace RpgFight.Dtos.Class
{
    public class GetClassDto
    {
        public int Id { get; set; }
        public List<GetEffectDto>? Effects { get; set; }
    }
}