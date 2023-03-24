using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Dtos.Effect
{
    public class GetEffectDto
    {
        public int Id {get;set;}
        public string Name { get; set; } = string.Empty;
        public int Intensity { get; set; }
        public bool Self { get; set; }
        public int Duration { get; set; }
    }
}