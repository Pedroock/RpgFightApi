using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Models
{
    public class User
    {
        public int Id {get;set;}
        public string Username {get;set;} = string.Empty;
        public byte[] PasswordHash {get;set;} = new byte[0];
        public byte[] PasswordSalt {get;set;} = new byte[0];
        public Character? Characters {get;set;}
        public BattleCharacter? BattleCharacters {get;set;}
        public BattleEnemy? BattleEnemys {get;set;}
    }
}