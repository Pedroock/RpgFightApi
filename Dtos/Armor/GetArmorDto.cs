using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Dtos.Armor
{
    public class GetArmorDto
    {
        public string Name { get; set; } = string.Empty;
        public Effect? Effect { get; set; }
        public int Price {get;set;}
    }
}