using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class FightResponse
    {
        public string Intro { get; set; } = string.Empty;
        List<RoundResponse>? Round {get;set;}
        public string Outro {get;set;} = string.Empty;
    }
}