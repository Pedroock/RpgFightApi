using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Dtos.Enemy
{
    public class AddEnemyDto
    {
        public string Name {get;set;} = string.Empty;
        public int Strength {get;set;} = 10;
        public int Intelligence {get;set;} = 10;
        public int Defense {get;set;} = 10;
    }
}