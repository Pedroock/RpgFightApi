using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name {get;set;} = string.Empty;
        public int HitPointModifier {get;set;}
        public int StrengthModifier {get;set;}
        public int IntelligenceModifier {get;set;}
        public int DefenseModifier {get;set;}
        public List<ClassEffect>? ClassEffects { get; set; }
    }
}