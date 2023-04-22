using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RpgFight.Models;
using RpgFight.Dtos.User;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Character;
using RpgFight.Dtos.Class;
using RpgFight.Dtos.Effect;
using RpgFight.Dtos.Enemy;
using RpgFight.Dtos.Skill;
using RpgFight.Dtos.Weapon;
using RpgFight.Models.Joins;
using RpgFightApi.Models.Joins;
using RpgFight.Migrations;

namespace RpgFight
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<Armor, GetArmorDto>();
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Class, GetClassDto>();
            CreateMap<Effect, GetEffectDto>();
            CreateMap<Enemy, GetEnemyDto>();
            CreateMap<AddEnemyDto, Enemy>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<RpgFight.Models.Joins.BattleModelEffect, RpgFightApi.Models.Joins.RebootEffect>();
        }
    }
}