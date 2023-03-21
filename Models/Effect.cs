using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class Effect
    {
        public int Id {get;set;}
        public string Name { get; set; } = string.Empty;
        public int Intensity { get; set; }
        public bool Self { get; set; }
    }
}