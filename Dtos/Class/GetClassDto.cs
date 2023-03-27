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
        public string Name { get; set; } = string.Empty;
        public int HitPointModifier {get;set;}
        public int StrengthModifier {get;set;}
        public int IntelligenceModifier {get;set;}
        public int DefenseModifier {get;set;}
    }
}