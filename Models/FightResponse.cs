using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class FightResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Intro { get; set; } = string.Empty;
        public T? Rounds {get;set;}
        public string Outro {get;set;} = string.Empty;
    }
}