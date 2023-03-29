using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name {get;set;} = string.Empty;
        public int Strength {get;set;}
        public int Intelligence {get;set;}
        public int Defense {get;set;}
    }
}