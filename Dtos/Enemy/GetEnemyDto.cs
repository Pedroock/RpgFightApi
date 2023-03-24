using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Dtos.Class;
using RpgFight.Dtos.Weapon;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Skill;

namespace RpgFight.Dtos.Enemy
{
    public class GetEnemyDto
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public int HitPoint {get;set;}
        public int Strength {get;set;}
        public int Intelligence {get;set;}
        public int Defense {get;set;}
        public GetClassDto? Class {get;set;}
        public GetWeaponDto? Weapon {get;set;}
        public GetArmorDto? Armor {get;set;}
        public GetSkillDto? Skill { get; set; }
    }
}