using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class Armor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Effect? Effect { get; set; }
        public int Price {get;set;}
        public List<Character>? Characters {get;set;} 
    }
}