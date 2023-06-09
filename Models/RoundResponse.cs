using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.Effect;

namespace RpgFight.Models
{
    public class RoundResponse
    {
        public string Message {get;set;} = string.Empty;
        public string Effects { get; set; } = string.Empty;
        public string CharacterAction { get; set; } = string.Empty;
        public string EnemyAction { get; set; } = string.Empty;
        public int CharacterHP { get; set; }
        public int EnemyHP { get; set; }
    }
}